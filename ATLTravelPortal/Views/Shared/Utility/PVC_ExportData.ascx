<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="exportData_c" class="float-right" style="position:relative;" >
    <input type="button"  value="Export" runat="server" ID="lnkExport" class="cmdButton cmdExportButton" 
    onclick="ToogleThemeView('exportDataDialogue_c');" />
    
    <div id="exportDataDialogue_c" class="exportPopUp" >
    <ul >

    <li  onmouseover="this.className='GridRowOver'" onmouseout="this.className='GridItem'" class="GridItem">
    <input type="image" id="ExportTypeExcel" src="../../../Content/Icons/Excel.png" name="ExportTypeExcel" value="Search" alt="Excel Format"/>
</li>
    <li  onmouseover="this.className='GridRowOver'" onmouseout="this.className='GridItem'" class="GridItem"><input type="image" id="ExportTypeWord" src="../../../Content/Icons/Word.png" name="ExportTypeWord" value="Search" alt="Word Format" /></li>
    <li  onmouseover="this.className='GridRowOver'" onmouseout="this.className='GridItem'" class="GridItem"><input type="image" id="ExportTypePdf" src="../../../Content/Icons/Pdf.png" name="ExportTypePdf" value="Search" alt="Pdf Format" /></li>
    
    </ul>
       
    </div>
    
</div>

