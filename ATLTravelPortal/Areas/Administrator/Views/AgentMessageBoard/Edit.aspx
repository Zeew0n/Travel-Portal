﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentMessageBoardModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%using (Html.BeginForm())
  { %>
  
     <div class="pageTitle">
        <div  class="float-right">
            	 <input type="submit" value="Save" class="save" />
                  <%:Html.ActionLink("Cancel", "Index", new { controller = "AgentMessageBoard" }, new { @class = "linkButton float-right" })%>
                
                
            </div>
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong> Message Board</strong>
        </h3>
    </div>

    <div class="form-box1">
     <%Html.RenderPartial("Utility/PVC_MessagePanel"); %> 
    <%:Html.HiddenFor(model => model.MessageBoardId) %>
        <div class="row-1">
           <%-- <div>
                <label>
                    <%int len;
                      try { len = Model.AgentList.ToList().Count - 1; }
                      catch (Exception ex)
                      {
                          len = 0;
                      }
                      finally { len = 0; }
           
                    %>
                    <%:Html.Label("Is For All Agent")%></label>
                <%:Html.CheckBoxFor(model => model.IsForAllAgent, new { @class = "ChkBoxParent" })%>
            </div>--%>
            <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%int len;
                          try { len = Model.AgentList.ToList().Count - 1; }
                          catch (Exception ex)
                          {
                              len = 0;
                          }
                          finally { len = 0; }
           
                        %>
                        <%:Html.Label("Is For All Agent") %></label>
                    <%:Html.CheckBoxFor(model => model.IsForAllAgent, new { @class = "ChkBoxParent" })%>
                </div>
            </div>

             <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%int len1;
                          try { len1 = Model.ProductList.ToList().Count - 1; }
                          catch (Exception ex)
                          {
                              len1 = 0;
                          }
                          finally { len1 = 0; }
           
                        %>
                        <%:Html.Label("Is For All Product") %></label>
                    <%:Html.CheckBoxFor(model => model.IsForAllProduct, new { @class = "ChkBoxParent" })%>
                </div>
            </div>
        </div>

         <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
            <div>
             <label> <%:Html.Label("Agents")%></label>
            <ul class="checklist">
                <%foreach (var item in Model.AgentList)
                  { %>
                
                   <%--<li> <%:Html.Label(item.AgentName)%></li>--%>
                   <li> <%if (Model.IsForAllAgent == true)
                      { %>
                 <input type="checkbox" name="ChkAgentId" value="<%=item.AgentId%>" class="ChkBoxChild" checked="checked"   />
              <%}
                      else
                      { %>
                           <%if (Model.AgentIdList.Contains(item.AgentId.ToString()))
                             {%>
                         
                              <input type="checkbox" name="ChkAgentId" value="<%=item.AgentId%>" class="ChkBoxChild" checked="checked"   />
                           <%}
                             else
                             { %>
                                 <input type="checkbox" name="ChkAgentId" value="<%=item.AgentId%>" class="ChkBoxChild"  />
                                 <%} %>
                              
                            <!-- end of if condition -->
                       
                      <%} %> <%: item.AgentName%></li>

                 
                              
                 <% }
                     
                %>
            </ul>
            </div>
  
            </div>

            <div class="form-box1-row-content float-right">
            <div>
             <label> <%:Html.Label("Products")%></label>
              <ul class="checklist">
                <%foreach (var item in Model.ProductList)
                  { %>
                <li><%if (Model.IsForAllProduct == true)
                      { %>
                        <input type="checkbox" name="ChkProductId" value="<%: item.ProductId%>" class="ChkBoxChild" checked="checked" />
              <%}
                        else
                      { %>
                           <%if (Model.ProductIdList.Contains(item.ProductId.ToString()))
                             {%>
                         
                              <input type="checkbox" name="ChkProductId" value="<%: item.ProductId%>" class="ChkBoxChild" checked="checked"   />
                           <%}
                             else
                             { %>
                                 <input type="checkbox" name="ChkProductId" value="<%: item.ProductId%>" class="ChkBoxChild"  />
                                 <%} %>
                       
                      <%} %>
                   
                        <%:(item.ProductName)%>
                    
                     </li>
                              
                 <% }
                     
                %>
            </ul>
            </div>
            </div>





            </div>

            <%-- <div class="form-box1-row">
            <div class="form-box1-row-content float-right">
              <%:Html.Label("Products")%>
              <ul class="checklist">
                <%foreach (var item in Model.ProductList)
                  { %>
                <li>
                <%:Html.Label(item.ProductName)%>
                    <%if (Model.IsForAllProduct == true)
                      { %>
                        <input type="checkbox" name="ChkProductId" value="<%: item.ProductId%>" class="ChkBoxChild" checked="checked" />
              <%}
                        else
                      { %>
                           <%if (Model.ProductIdList.Contains(item.ProductId.ToString()))
                             {%>
                         
                              <input type="checkbox" name="ChkProductId" value="<%: item.ProductId%>" class="ChkBoxChild" checked="checked"   />
                           <%}
                             else
                             { %>
                                 <input type="checkbox" name="ChkProductId" value="<%: item.ProductId%>" class="ChkBoxChild"  />
                                 <%} %>
                       
                      <%} %>
                   
                     </li>
                              
                 <% }
                     
                %>
            </ul>
            </div>
            </div>--%>
            
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%:Html.Label("Message Type")%></label>
                        <%:Html.DropDownListFor(model => model.MessageTypeId, Model.ddlMsgType)%>
                        <%:Html.ValidationMessageFor(model => model.MessageTypeId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Message Priority")%></label>
                        <%: Html.DropDownListFor(model => model.PriorityId, Model.ddlMsgPriorities)%>
                        <%:Html.ValidationMessageFor(model => model.PriorityId)%>
                    </div>
                </div>
            </div>

             <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Message Category")%></label>
                    <%: Html.DropDownListFor(model => model.MessageCatagoriesId, Model.MessageCatagories)%>
                    <%:Html.ValidationMessageFor(model => model.MessageCatagoriesId)%>
                </div>
            </div>

            <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Heading Content")%></label>
                        <%:Html.TextAreaFor(model => model.HeadContains)%>
                        <%:Html.ValidationMessageFor(model => model.HeadContains)%>
                    </div>
                </div>
        </div>


            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   <div style="padding-left: 10px; padding-top: 10px; width: 805px; float: left">
                        <label>
                            <%:Html.Label("Message Content")%></label>
                        <%--<%:Html.TextAreaFor(model => model.MessageContains)%>
                        <%:Html.ValidationMessageFor(model => model.MessageContains)%>--%>
                         <%= Html.TextArea("MessageContains", Model.MessageContains, new { @class = "ckeditor" })%>
                    </div>
                </div>
                
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Effective From")%></label>
                        <%:Html.TextBox("EffectiveFrom")%>
                        <%:Html.ValidationMessageFor(model => model.EffectiveFrom)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.Label("Expire On")%></label>
                        <%:Html.TextBox("ExpiredOn")%>
                        <%:Html.ValidationMessageFor(model => model.ExpiredOn)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                </div>
            </div>
        </div>
        <div  class="buttonBar">
            	 <input type="submit" value="Save" class="save" />
                  <%:Html.ActionLink("Cancel", "Index", new { controller = "AgentMessageBoard" }, new { @class = "linkButton float-right" })%>
                
                
            </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
        <script src="../../../../Content/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ddaccordion.js" type="text/javascript"></script>





    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            //Cheked/UnChecked all child check box if parent check box is Checked/Unchecked .
            $('.ChkBoxParent').click(function () {
                $('.ChkBoxChild').attr('checked', $(this).attr('checked'));
            });

            $('.ChkBoxChild').click(function () {
                var childCheckBox = $('.ChkBoxChild');
                var checkedAllStatus = true;
                for (var i = 0; i < childCheckBox.length; i++) {
                    if (!$(childCheckBox[i]).is(':checked')) {
                        checkedAllStatus = false;
                    }
                }
                $('.ChkBoxParent').attr('checked', checkedAllStatus);
            });

        });

        $(function () {
            var dates = $("#EffectiveFrom, #ExpiredOn").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                onSelect: function (selectedDate) {
                    var option = this.id == "EffectiveFrom" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });
        });


        function EnableDisableElementBySelectionAppliedDate(thisElm, targetElm) {
            if (thisElm == "checked") {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).val("")
            }
            else {
                $("#" + targetElm).removeAttr('disabled', 'disabled');
            }
        }


    </script>

      <script type="text/javascript" language="javascript">
          $(document).ready(function () {
              var config = {
                  toolbar:
                      [
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                        ['Link', 'Unlink', 'Anchor'],
                        ['Image', 'Table', 'HorizontalRule', 'SpecialChar', 'PageBreak'],
                        '/',
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor'],
                        ['-']
                      ]
              };
              CKEDITOR.replace('MessageContains', config);

          });


    </script>
</asp:Content>
