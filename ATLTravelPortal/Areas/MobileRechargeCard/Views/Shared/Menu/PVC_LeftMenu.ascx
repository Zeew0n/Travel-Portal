<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>


<div class="applemenu">
                    <%if (Page.User.Identity.IsAuthenticated)
                      {%>
                    <%if ((obj != null && obj.UserTypeId == (int)UserTypes.SuperUser) || (obj != null && obj.UserTypeId == (int)UserTypes.SuperUser))
                      {%>
                     
                    <div class="silverheader">
                        <a href="#">Setup</a></div>
                    <div class="submenu">
                        <ul>
                             <li> <%:Html.ActionLink("Service Provider ", "Index", new {controller = "MobileServiceProvider", area = "MobileRechargeCard" })%></li>             
                             <li> <%:Html.ActionLink("Card Type Name ", "Index", new {controller = "CardType", area = "MobileRechargeCard" })%></li>             
                             <li> <%:Html.ActionLink("Card Value ", "Index", new {controller = "MobileServiceProvider", area = "MobileRechargeCard" })%></li>             
                             <li> <%:Html.ActionLink("Uplode Inventory ", "Index", new {controller = "MobileServiceProvider", area = "MobileRechargeCard" })%></li>             
                             <li> <%:Html.ActionLink("Send Pin ", "Index", new {controller = "MobileServiceProvider", area = "MobileRechargeCard" })%></li>             
                        </ul>
                    </div>
                    <div class="silverheader">
                        <a href="#">Reports</a></div>
                    <div class="submenu">
                        <ul>
                                 <li></li>
                                 <li></li>
                                  <li></li>
                        </ul>
                    </div>

                     <div class="silverheader">
                        <a href="#">Settings</a></div>
                    <div class="submenu">
                        <ul>
                                 <li></li>
                                 <li></li>
                                 <li></li>
                                 <li></li>
                                
                        </ul>
                    </div>

                    

                 
                    <%} %>
    
                    <%}%>
                </div>