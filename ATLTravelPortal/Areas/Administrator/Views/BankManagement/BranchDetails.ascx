<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<div class="row-1">
<table style="width: 100%; border: 1px solid gray;">
<div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <label>
                        Branch :</label>
                        <%:Model.BranchName %>
                </div>
                <div class="form-box1-row-content float-right">
                <label>
                 Address:
                </label>
                <%:Model.BranchAddress %>
                </div>
            </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <label>
                        Phone No:</label>
                        <%:Model.BranchPhoneNumber %>
                </div>
                <div class="form-box1-row-content float-right">
                <label>
               Contact Person:
                </label>
                <%:Model.BranchContactPerson %>
                </div>
            </div>

            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <label>
                        Contact Phone No:</label>
                        <%:Model.BranchPhoneNumber %>
                </div>
                <div class="form-box1-row-content float-right">
                <label>
               Contact Mobile No:
                </label>
                <%:Model.BranchContactPhoneNo %>
                </div>
            </div>

            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <label>
                        Email:</label>
                        <%:Model.BranchContactEmail %>
                </div>
                
            </div>
        </div>
        
        <tr>
        <td></td>
        <td>
        <input type="button" value="Cancel" class="btn1" onclick="Hide();" />
        </td>
        </tr>
</table>

        </div>
        <script language="javascript" type="text/javascript">
            function Hide() {
                $("#Detail").css('visibility', 'hidden');
            }

                            </script>