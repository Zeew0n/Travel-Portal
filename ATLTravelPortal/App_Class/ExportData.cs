using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace ATLTravelPortal.App_Class
{
    public class ExportData
    {

        public static void Export(int formatType, string fileName, GridView gv)
        {
            if (formatType == 1)
            {
                ExportData.ExportExcel(fileName, gv);
            }
            else if (formatType == 2)
            {
                ExportData.ExportPDF(fileName, gv);
            }
            else if (formatType == 3)
            {
                ExportData.ExportWord(fileName, gv);
            }
            else if (formatType == 4)
            {
                ExportData.ExportCSV(fileName, gv);
            }
        }
       

        public static void ExportPDF(string fileName, GridView gv)
        {
            fileName = fileName.TrimEnd().TrimStart().Replace(' ', '_');

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.pdf", fileName));
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();
                    table.BorderWidth = 1;
                      gv.Width = 100;
                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        ExportData.PrepareControl(gv.HeaderRow);
                        gv.HeaderRow.BackColor = System.Drawing.Color.WhiteSmoke;
                        
                        gv.HeaderRow.BorderWidth = 1;
                        gv.HeaderRow.BorderColor = System.Drawing.Color.Black;
                        table.Rows.Add(gv.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        int rowint = row.RowIndex;
                        row.BorderColor = System.Drawing.Color.Black;
                        ExportData.PrepareControl(row);
                        table.Rows.Add(row);

                    }
                    
                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        ExportData.PrepareControl(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);
                    //-------------------------------------------
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f,0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    HttpContext.Current.Response.Write(pdfDoc);
                    HttpContext.Current.Response.End();
                    //-------------------------------------------

                }
            }
        }


        public static void ExportExcel(string fileName, GridView gv)
        {
            fileName = fileName.TrimEnd().TrimStart().Replace(' ', '_');

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}.xls", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table() ;
                    table.Width = 100;


                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        ExportData.PrepareControl(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        ExportData.PrepareControl(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        ExportData.PrepareControl(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }


        public static void ExportWord(string fileName, GridView gv)
        {
            fileName = fileName.TrimEnd().TrimStart().Replace(' ', '_');

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}.doc", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-Word";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();

                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        ExportData.PrepareControl(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        ExportData.PrepareControl(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        ExportData.PrepareControl(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }

        public static void ExportCSV(string fileName, GridView gv)
        {
            fileName = fileName.TrimEnd().TrimStart().Replace(' ', '_');

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}.csv", fileName));
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/text";

            gv.AllowPaging = false;
            gv.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int k = 0; k < gv.Columns.Count; k++)
            {
                //add separator
                sb.Append(gv.Columns[k].HeaderText + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                for (int k = 0; k < gv.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(gv.Rows[i].Cells[k].Text + ',');
                }
                //append new line
                sb.Append("\r\n");
            }
            HttpContext.Current.Response.Output.Write(sb.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }


        private static void PrepareControl(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    ExportData.PrepareControl(current);
                }
            }
        }



    }
}