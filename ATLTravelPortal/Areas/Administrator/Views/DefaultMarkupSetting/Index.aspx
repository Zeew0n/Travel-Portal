<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlinePortalMain.Master" Inherits="System.Web.Mvc.ViewPage<ATBackOffice.Models.Admin.DefaultMarkupSettingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <div class="box3">
        	<div class="userinfo">
           <h3>Default Markup Setting</h3>
            </div>
            
            <div class="buttons-panel">
            	<ul>
                <li>
                <input type="submit" value="Save" class="save" />
                </li>
                
                	<%--<li class="create"><a href="#">Create</a></li>--%>
                    <%--<li class="showall" onclick="document.location.href='/DefaultMarkupSetting/Edit'"><a>Add Airline Markup</a></li>--%>
                </ul>
            </div>    	
        </div>

            <div class="row-1">
           		
            	<div class="form-box1 round-corner">

                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label>   <%: Html.LabelFor(model => model.MiniumMarkupValue) %></label>
                                    <%: Html.TextBoxFor(model => model.MiniumMarkupValue) %>
                                    <%: Html.ValidationMessageFor(model => model.MiniumMarkupValue) %>
                                 </div> 
                            </div>                           
                        </div>                        
             
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label>  <%: Html.LabelFor(model => model.MaximumMarkupValue) %></label>
                                   <%: Html.TextBoxFor(model => model.MaximumMarkupValue) %>
                                     <%: Html.ValidationMessageFor(model => model.MaximumMarkupValue) %>
                                </div>                            
                        </div>                        
                    </div>

                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label> <%: Html.LabelFor(model => model.DefaultMarkupValue) %></label>
                              <%: Html.TextBoxFor(model => model.DefaultMarkupValue) %>
                                <%: Html.ValidationMessageFor(model => model.DefaultMarkupValue) %>
                                </div>                            
                        </div>                        
                    </div>
                  
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label><%: Html.LabelFor(model => model.isApplyOnAllEgent) %></label>
                               <%:Html.CheckBoxFor(model => model.isApplyOnAllEgent)%>
                               </div>                            
                        </div>                        
                    </div>                             
                             
                 
                    <%--<div class="form-box1-row">
                        <p class="mrg-lft-130">
                            <input type="submit" value="Create" class="btn1" />                            
                        </p>                        
                    </div>  --%>
                                                       
                </div>
            </div>

<%--
        <fieldset>
            
             <div class="editor-label">
                <%: Html.LabelFor(model => model.MiniumMarkupValue) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MiniumMarkupValue) %>
                <%: Html.ValidationMessageFor(model => model.MiniumMarkupValue) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.MaximumMarkupValue) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MaximumMarkupValue) %>
                <%: Html.ValidationMessageFor(model => model.MaximumMarkupValue) %>
            </div>
          </fieldset>
        <fieldset>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.DefaultBesinussValue) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DefaultBesinussValue) %>
                <%: Html.ValidationMessageFor(model => model.DefaultBesinussValue) %>
            </div>
          
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DefaultEcnomyValue) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DefaultEcnomyValue) %>
                <%: Html.ValidationMessageFor(model => model.DefaultEcnomyValue) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DefaultMarkupValue) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DefaultMarkupValue) %>
                <%: Html.ValidationMessageFor(model => model.DefaultMarkupValue) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.isApplyOnAllEgent) %>
            </div>
            <div class="editor-field">
               <%:Html.CheckBoxFor(model => model.isApplyOnAllEgent)%>
            </div>
            </fieldset>
            <p>
                <input type="submit" value="Create" />
            </p>
        --%>

    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

