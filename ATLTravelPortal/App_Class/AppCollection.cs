using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.App_Class
{
    public class AppCollection
    {


        public static void ExportCore(IEnumerable<dynamic> xpData, int exportFormat, string fileName)
        {

            if (xpData != null)
            {
                //DataTable dt = ObtainDataTableFromIEnumerable(xpData);

                GridView ExportGrid = new GridView();
                //DataTable ExportDataTable = dt;
                ExportGrid.Width = 100;
                ExportGrid.AllowPaging = false;
                ExportGrid.DataSource = xpData;
                ExportGrid.DataBind();
               
                App_Class.ExportData.Export(exportFormat, fileName, ExportGrid);

            }
        }

        //public static void Export(WaitListRequestModel model, IEnumerable<dynamic> exportData, string fileName)
        //{
        //    if (model != null && (model.ExportTypeExcel != null || model.ExportTypeWord != null || model.ExportTypeCSV != null || model.ExportTypePdf != null))
        //    {

        //        if (model.ExportTypeExcel != null)
        //        {
        //            App_Class.AppCollection.ExportCore(exportData, 1, fileName);
        //        }
        //        else if (model.ExportTypeWord != null)
        //        {
        //            App_Class.AppCollection.ExportCore(exportData, 3, fileName);
        //        }
        //        else if (model.ExportTypeCSV != null)
        //        {
        //            App_Class.AppCollection.ExportCore(exportData, 4, fileName);
        //        }
        //        else if (model.ExportTypePdf != null && exportData.Count() > 0)
        //        {
        //            App_Class.AppCollection.ExportCore(exportData, 2, fileName);
        //        }
        //    }
        //}


        public static void ExportIssuedTicket(IssuedTicketModel model, IEnumerable<dynamic> exportData, string fileName)
        {
            if (model != null && (model.ExportTypeExcel != null || model.ExportTypeWord != null || model.ExportTypeCSV != null || model.ExportTypePdf != null))
            {

                if (model.ExportTypeExcel != null)
                {
                    App_Class.AppCollection.ExportCore(exportData, 1, fileName);
                }
                else if (model.ExportTypeWord != null)
                {
                    App_Class.AppCollection.ExportCore(exportData, 3, fileName);
                }
                else if (model.ExportTypeCSV != null)
                {
                    App_Class.AppCollection.ExportCore(exportData, 4, fileName);
                }
                else if (model.ExportTypePdf != null && exportData.Count() > 0)
                {
                    App_Class.AppCollection.ExportCore(exportData, 2, fileName);
                }
            }
        }


        public static void Export(ExportModel model, IEnumerable<dynamic> exportData, string fileName)
        {
            if (model != null && (model.ExportTypeExcel != null || model.ExportTypeWord != null || model.ExportTypeCSV != null || model.ExportTypePdf != null))
            {

                if (model.ExportTypeExcel != null)
                {
                    App_Class.AppCollection.ExportCore(exportData, 1, fileName);
                }
                else if (model.ExportTypeWord != null)
                {
                    App_Class.AppCollection.ExportCore(exportData, 3, fileName);
                }
                else if (model.ExportTypeCSV != null)
                {
                    App_Class.AppCollection.ExportCore(exportData, 4, fileName);
                }
                else if (model.ExportTypePdf != null && exportData.Count() > 0)
                {
                    App_Class.AppCollection.ExportCore(exportData, 2, fileName);
                }
            }
        }



    }
}