<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserInvoice.aspx.cs" Inherits="SandysBakery.Views.User.UserInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel panel-info">
        <h4 class="card-title" align="center">Invoice</h4>
        <div class="panel-body">
            <div class="toolbar hidden-print">
                <div class="text-right">
                    <button id="printInvoice" class="btn btn-info"><i class="fa fa-print"></i>Print</button>

                </div>
                <hr>
            </div>
            <div class="invoices">
                <%
                    SandysBakery.BusinessLogic.UsersLogin usersLogin = Session["UsersLogin"] as SandysBakery.BusinessLogic.UsersLogin;
                    SandysBakery.DataAccess.Services.IAdministrator administrator = new SandysBakery.DataAccess.Services.Administrator();
                    System.Data.DataTable dataTable = administrator.DisplayOrderedItems(usersLogin.UserId, usersLogin.RoleName, dateTime: addedDate);
                    List<SandysBakery.BusinessLogic.Order> productCategories = new SandysBakery.DataAccess.Adaptors.Helper().DataTableToListof<SandysBakery.BusinessLogic.Order>(dataTable);
                %>
                <div class="col-md-12 text-right">

                    <p class="mb-1"><span class="text-muted">Full Name: </span><%=productCategories.Select(x => x.FullName).FirstOrDefault() %></p>
                    <p class="mb-1"><span class="text-muted">Date: </span><%=productCategories.Select(x => x.OrderDate.ToShortDateString()).FirstOrDefault() %></p>
                    <p class="mb-1"><span class="text-muted">Status: </span><%=productCategories.Select(x => x.ActiveStatus).FirstOrDefault() %></p>
                    <p class="mb-1"><span class="text-muted">Payment Type: </span><%=productCategories.Select(x => x.StatusName).FirstOrDefault() %></p>
                     <p class="mb-1"><span class="text-muted">Card Number: </span><%=productCategories.Select(x => x.CardNumber).FirstOrDefault() %></p>
                </div>
                <div class="row p-5">
                    <div class="col-md-12">
                        <table class="table">
                            <thead>
                                <tr>

                                    <th class="border-0 text-uppercase small font-weight-bold">Item</th>
                                    <th class="border-0 text-uppercase small font-weight-bold">Quantity</th>
                                    <th class="border-0 text-uppercase small font-weight-bold">Unit Cost</th>
                                    <th class="border-0 text-uppercase small font-weight-bold">Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in productCategories)
                                    {

                                %>
                                <tr>
                                    <td><%=item.ItemName %></td>
                                    <td class="text-right"><%=item.TotalOrderQuantity %></td>
                                    <td class="text-right"><%=item.Price/item.TotalOrderQuantity %></td>
                                    <td class="text-right"><%=item.Price %></td>

                                </tr>
                                <% } %>
                                <tr>
                                    <td colspan="3" class="font-weight-bold">Total</td>
                                    <td class="text-right font-weight-bold"><%=productCategories.Sum(x=>x.Price) %></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        </div>
    <script>
        $('#printInvoice').click(function () {
            Popup($('.invoices')[0].outerHTML);
            function Popup(data) {
                window.print();
                return true;
            }
        });
    </script>
</asp:Content>