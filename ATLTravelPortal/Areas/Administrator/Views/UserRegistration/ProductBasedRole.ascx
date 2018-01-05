<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel+CreateAdminAspUser>" %>
<div class="row-1">
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div id="MyDiv">
                <h5>
                    Choose Product</h5>
                <div>
                    <ul class="productselection-box ">
                        <% foreach (var Products in Model.ProductBaseRoleList)
                           { %>
                        <li>
                            <img src="../../../../Content/images/productimage/<%=Products.ProductId%>.jpg" alt=""
                                id='img3' />
                            <input type="checkbox" name="ChkProductId" value="<%=Products.ProductId%>" id="ProductId<%=Products.ProductId%>"
                                class="ProductId" />
                            <% =Products.ProductName%>
                            <br />
                            <label>
                                Role:</label>
                            <%=Html.DropDownList("RoleId" + Products.ProductId, Model.RoleList, "-----Select-----", new { @id = "RoleId" + Products.ProductId })%>
                            <%--   <%: Html.DropDownListFor(model => model.RoleId, Model.RoleList, "-----Select-----")%>--%>
                            <%}%>
                        </li>
                    </ul>
                </div>
            </div>
            <div id="check_IfChecked" class="checkIfExsit">
            </div>
        </div>
    </div>
</div>
<%--     <% for (int i = 0; i < Model.ProductBaseRoleList.Count; i++) 
                             { %>
            
                           <%: Html.EditorFor(model => model.ProductBaseRoleList[i])%>

                           <% } %>--%>