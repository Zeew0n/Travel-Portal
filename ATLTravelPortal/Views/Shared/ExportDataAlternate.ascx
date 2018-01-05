<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="exportData_c" >
    <input type="button"  value="Export" runat="server" ID="lnkExport" class="cmdButton cmdExportButton" 
    onclick="ToogleThemeView('exportDataDialogue_a');" />
    <div id="exportDataDialogue_a" style="display: none;">
        <table class="GridView" cellpadding="0" cellspacing="0" style="border:1px solid">
            <tr onmouseover="this.className='GridRowOver'" onmouseout="this.className='GridItem'" class="GridItem">
                <td style="width:30px;">  
                 <%--   <button><input type="image" src="../../../Content/Icons/Excel.png" title="Export Data in Excel Format" alt="Excel" id="cmdExcel" class="imgClass"
                value="Excel" name="cmdExcel_Command" CommandArgument="1" /></button>--%>
                <input type="image" id="ExportTypeExcel" src="../../../Content/Icons/Excel.png" name="ExportTypeExcel" value="Search" />
                </td>
                <td style="width:100px;">  
                    <label class="LabelView" id="lblExportExcel" >Excel Format</label>
                </td>
            </tr>
            <tr onmouseover="this.className='GridRowOver'" onmouseout="this.className='GridItem'" class="GridItem">
                <td>
                   <a target="frameHiddenExport" type="image" title="Export Data in Word Format" id="cmdWord" class="imgClass"
                value="Word" name="cmdWord_Command" CommandArgument="3" >
                <%--<img  alt="Word" src="../../../Content/Icons/Word.png" onclick="jqueryPostUrlTest(document.forms[0],'/ComSetupAppOption/Export/','');"   /></a>--%>
                   <input type="image" id="ExportTypeWord" src="../../../Content/Icons/Word.png" name="ExportTypeWord" value="Search" />

                </td>
                <td>
                    <label class="LabelView" id="lblExportWord" >Word Format</label>
                </td>
            </tr>
            <%--<tr onmouseover="this.className='GridRowOver'" onmouseout="this.className='GridItem'" class="GridItem">
                <td>                     
                <input type="image" id="ExportTypeCSV" src="../../../Content/Icons/CSV.png" name="ExportTypeCSV" value="Search" />
                </td>
                <td>
                    <label class="LabelView" id="lblExportCSV" >CSV Format</label>
                </td>
            </tr>--%>
            <tr onmouseover="this.className='GridRowOver'" onmouseout="this.className='GridItem'" class="GridItem">
                <td>
                   <%-- <button><input type="image" src="../../../Content/Icons/Pdf.png" title="Export Data in PDF Format" alt="PDF" id="cmdPdf" class="imgClass"
                value="PDF" name="cmdPdf_Command" CommandArgument="2" /></button>--%>
                <input type="image" id="ExportTypePdf" src="../../../Content/Icons/Pdf.png" name="ExportTypePdf" value="Search" />
                </td>
                <td>
                    <label class="LabelView" id="lblExportPdf" >Pdf Format</label>
                </td>
            </tr>
        </table>
    </div>
    
</div>

