<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SandysBakery.Views.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <%
            SandysBakery.DataAccess.Services.IAdministrator administrator = new SandysBakery.DataAccess.Services.Administrator();
            var products = administrator.ProductItemsPerCategoryById(categoryId);
            foreach (var item in products)
            {
                ImgProfilePic.ImageUrl = item.ImagePath;
        %>

        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card h-100">
                <a href="\Views/ProductDetails.aspx?ProductItemsId=<%=item.ProductItemsId %>">
                    <asp:Image ID="ImgProfilePic" runat="server"  class="card-img-top" />
                  </a>
                <div class="card-body">
                    <h4 class="card-title">
                       <a href="\Views/ProductDetails.aspx?ProductItemsId=<%=item.ProductItemsId %>"><%=item.ItemName %></a>
                    </h4>
                    <h5><%=item.SellingPrice.ToString ("0.00") %></h5>
                    <p class="card-text"></p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
                </div>
            </div>
        </div>
        <% }%>
    </div>
</asp:Content>