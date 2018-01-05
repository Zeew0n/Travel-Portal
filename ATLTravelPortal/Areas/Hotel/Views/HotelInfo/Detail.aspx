<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelInfos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="contentGrid" id="result">
<%var item = Model; %>
    <h2>
        Details</h2>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
            <div class="form-box1-row-content float-left">                          
                                <div><label>Hotel Name:</label> 
                                      <%: item.HotelName %>
                                </div>                          
                        </div>
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Code:</label>
                                       <%: item.HotelCode %>
                                </div>                          
                        </div>
        

            
            <div class="form-box1-row-content float-left">                          
                                <div><label>Web:</label> 
                                      <%: item.Web%>
                                </div>                          
                        </div>
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Email:</label>
                                       <%:item.Email %>
                                </div>                          
                        </div>
          
            
            <div class="form-box1-row-content float-left">                          
                                <div><label>Address:</label> 
                                      <%:item.Address %>
                                </div>                          
                        </div>
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Phone:</label>
                                       <%: item.Phone %>
                                </div>                          
                        </div>
           
           
            <div class="form-box1-row-content float-left">                          
                                <div><label>IsActive:</label> 
                                      <%:item.isActive %>
                                </div>                          
                        </div>
                    </div>    
             </div>
        </div>
    </div>  
 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
