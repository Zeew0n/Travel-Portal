using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Web.UI.WebControls;


namespace ATLTravelPortal.App_Class
{
    public class AppUploader
    {
        public static bool DeleteAllFileFromDirectory(string diretoryPath)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(diretoryPath);
                FileInfo[] rgFiles = di.GetFiles();
                foreach (FileInfo fi in rgFiles)
                {
                    FileInfo TheFile = new FileInfo(fi.FullName);
                    if (TheFile.Exists)
                    {
                        File.Delete(fi.FullName);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool DeleteFileByName(string directoryPath, string FileName)
        {
            try
            {
                //string[] filePaths = Directory.GetFiles(@"D:\workflow\WorkFlow3\WorkFlow\Content\Uploaded\Document", FileName);                
                string[] filePaths = Directory.GetFiles(directoryPath, FileName);                
                foreach (string file in filePaths)
                {
                    FileInfo TheFile = new FileInfo(file);
                    if (TheFile.Exists)
                    {
                        File.Delete(file);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CreateDirectory(string directoryName, string parentDirectoryPath)
        {
            try
            {
                string newDirectory = parentDirectoryPath +"\\"+ directoryName;
                if (Directory.Exists(newDirectory))
                {                   
                    return false;
                }

                DirectoryInfo di = Directory.CreateDirectory(newDirectory);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteDirectory(string diretoryPath)
        {
            try
            {                
                if (Directory.Exists(diretoryPath))
                {
                    Directory.Delete(diretoryPath, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsDirectoryExist(string directoryName, string parentDirectoryPath)
        {
            string newDirectory = parentDirectoryPath +"\\"+ directoryName;
            if (Directory.Exists(newDirectory))
            {
                return true;
            }
            return false;
        }

        public static bool IsFileExist(string directoryPath, string FileName)
        {
            string newDirectory = directoryPath + "\\" + FileName;
            if (File.Exists(newDirectory))
            {
                return true;
            }
            return false;
        }

        /* public static bool UploadFile(HttpPostedFileBase UploadedFile, string UploadDirPath = "~/Content/Uploaded/")
         {
             string UploadedFileName = UploadFileMaster(UploadedFile, UploadDirPath, UploadedFile.FileName);
             if (UploadedFileName != "")
             {
                 return UploadedFileName;
             }
             return true;

         }
         */

        public static string UploadDocumentAndRename(HttpPostedFileBase UploadedFile, ContentPathMode mode, string UploadDirPath = "~/Upload/Package")
        {
            string UploadedFileName = "";
            DateTime dt = DateTime.Now;
            string fileNamePrefix = "";
            if (UploadedFile.ContentLength > 0)
            {
                fileNamePrefix = Guid.NewGuid().ToString("D");
                var fileName = fileNamePrefix + Path.GetExtension(UploadedFile.FileName);
                UploadedFileName = UploadFileMaster(UploadedFile, mode, UploadDirPath, fileName);
            }
            return UploadedFileName;
        }

        public static string UploadFileAndRename(HttpPostedFileBase UploadedFile, ContentPathMode mode, string UploadDirPath = "~/Upload/Package",
            bool RenameInGuidFormat = true)
        {
            
            string UploadedFileName = "";
            DateTime dt = DateTime.Now;
            string fileNamePrefix = "";
            if (UploadedFile.ContentLength > 0)
            {
                if (RenameInGuidFormat)
                {

                    fileNamePrefix = AppGuid.NewGuid(Convert.ToChar("D")) + "__";
                }
                else
                {
                    fileNamePrefix = string.Format("{0:dd-MM-yyyy-HH.mm.ss}", dt) + "__";

                }
                var fileName = fileNamePrefix + Path.GetFileName(UploadedFile.FileName);
                UploadedFileName = UploadFileMaster(UploadedFile, mode, UploadDirPath, fileName);
            }
            return UploadedFileName;
        }

        private static string UploadFileMaster(HttpPostedFileBase UploadedFile, ContentPathMode mode, string UploadDirPath, string FileRenameToNewName = "")
        {
            string UploadedFileName = "";
            if (UploadedFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(UploadedFile.FileName);
                UploadedFileName = (FileRenameToNewName == "" ? fileName : FileRenameToNewName);
                string path = string.Empty;;
                if (mode.ToString() == "relative")
                {
                    path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(UploadDirPath), UploadedFileName);
                }
                else {
                    path = Path.Combine(UploadDirPath, UploadedFileName);
                
                }
                UploadedFile.SaveAs(path);

            }
            return UploadedFileName;

        }

        public enum ContentPathMode
        { 
            relative,
            absolute,
        
        }

        public static void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
        {
            System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

            // Prevent using images internal thumbnail
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            if (OnlyResizeIfWider)
            {
                if (FullsizeImage.Width <= NewWidth)
                {
                    NewWidth = FullsizeImage.Width;
                }
            }

            int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            if (NewHeight > MaxHeight)
            {
                // Resize with height instead
                NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                NewHeight = MaxHeight;
            }

            System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage.Dispose();

            // Save resized picture
            NewImage.Save(NewFile);
        }

        /* public static void SaveUploadedToDB(string diretoryPath)
         {
            string filePath = null;
            try{
               // DaleteUplodeCardDetail();
                 DirectoryInfo di = new DirectoryInfo(diretoryPath);
                 FileInfo[] rgFiles = di.GetFiles("*.xls");
                 foreach  (FileInfo fi in rgFiles)
                 {
                     filePath= fi.FullName;
                 }
               
                 string excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";	Extended Properties=Excel 8.0";

                 using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
                 {
                     OleDbCommand command = new OleDbCommand("Select Card_No,Account_No,Expiry_Date,Customer_Name FROM [Card_Data$]", connection);

                     connection.Open();
                     using (DbDataReader dr = command.ExecuteReader())
                     {
                         while (dr.Read())
                         { 
                             string CardNo=(string)dr["Card_No"];
                             string AccountNo=(string)dr["Account_No"];
                             DateTime ExpiryDate=DateTime.Parse(dr["Expiry_Date"].ToString());
                             string CustomerName=(string)dr["Customer_Name"];
                             //if(SaveUplodeCardDetail(CardNo.Trim(),AccountNo.Trim(),ExpiryDate,CustomerName.Trim())==true)
                             //{
                             //}
                         }
                     }
                 }
            }
             catch(Exception ex)
            {
                 throw ex;
             }
         }*/
        /* protected void ButtonBar1_Uplode_Click(object sender, EventArgs e)
         {
             try
             {
                 cUplodeCardNo uc = new cUplodeCardNo();
                 if (uc.DeleteAllFileFromDirectory(Server.MapPath("~/ExcelFile")) == true)
                 {
                     if (UplodeFile() == true)
                     {
                         uc.UplodeCardData(Server.MapPath("~/ExcelFile"));
                         gvUplodeCardList.DataBind();
                         WUC_ButtonBar2.Update_Visible = true;
                     }
                 }
             }
             catch (Exception ex)
             {
                 WUC_MessagePanel1.Visible = true;
                 WUC_MessagePanel1.Message = ex.Message;
                 WUC_MessagePanel1.MessageUrl = Resources.cwfGlobalResource.Message_ErrorImgUrl;
             }
         }*/

        /*private bool UplodeFile()
        {
            string serverFileName = Path.GetFileName(FileUpload.PostedFile.FileName);
            if (FileUpload.PostedFile.FileName != "")
                FileUpload.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/ExcelFile" + FileUpload.PostedFile.FileName));
            return true;
        }
       /* public void UplodeCardData(string diretoryPath)
        {
           string filePath = null;
           try{
               DaleteUplodeCardDetail();
            DirectoryInfo di = new DirectoryInfo(diretoryPath);
            FileInfo[] rgFiles = di.GetFiles("*.xls");
           foreach  (FileInfo fi in rgFiles)
            {
                filePath= fi.FullName;
            }
               
            string excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";	Extended Properties=Excel 8.0";

            using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
            {
                OleDbCommand command = new OleDbCommand("Select Card_No,Account_No,Expiry_Date,Customer_Name FROM [Card_Data$]", connection);

                connection.Open();
                using (DbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    { 
                        string CardNo=(string)dr["Card_No"];
                        string AccountNo=(string)dr["Account_No"];
                        DateTime ExpiryDate=DateTime.Parse(dr["Expiry_Date"].ToString());
                        string CustomerName=(string)dr["Customer_Name"];
                        if(SaveUplodeCardDetail(CardNo.Trim(),AccountNo.Trim(),ExpiryDate,CustomerName.Trim())==true)
                        {
                        }
                    }
                }
            }
           }
            catch(Exception ex)
           {
                throw ex;
            }
        }*/


    }
}