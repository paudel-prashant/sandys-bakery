<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="SandysBakery.Views.Admin.Invoice" %>
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
            <div class="invoice">
                <%
                    SandysBakery.BusinessLogic.UsersLogin usersLogin = Session["UsersLogin"] as SandysBakery.BusinessLogic.UsersLogin;
                    SandysBakery.DataAccess.Services.IAdministrator administrator = new SandysBakery.DataAccess.Services.Administrator();
                    System.Data.DataTable dataTable = administrator.DisplayOrderedItems(UserId, usersLogin.RoleName, "Admin", dateTime: addedDate);
                    List<SandysBakery.BusinessLogic.Order> orderedItems = new SandysBakery.DataAccess.Adaptors.Helper().DataTableToListof<SandysBakery.BusinessLogic.Order>(dataTable);

                %>
                <div class="col-md-12 text-right">
                    <p class="mb-1"><span class="text-muted">Full Name: </span><%=orderedItems.Select(x => x.FullName).FirstOrDefault() %></p>
                    <p class="mb-1"><span class="text-muted">Date: </span><%=orderedItems.Select(x => x.OrderDate.ToShortDateString()).FirstOrDefault() %></p>
                    <p class="mb-1"><span class="text-muted">Status: </span><%=orderedItems.Select(x => x.ActiveStatus).FirstOrDefault() %></p>
                    <p class="mb-1"><span class="text-muted">Payment Type: </span><%=orderedItems.Select(x => x.StatusName).FirstOrDefault() %></p>
                    <p class="mb-1"><span class="text-muted">Card Number: </span><%=orderedItems.Select(x => x.CardNumber).FirstOrDefault() %></p>
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
                                <%foreach (var item in orderedItems)
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
                                    <td colspan="3"><strong>Total</strong></td>
                                    <td class="text-right"><strong><%=orderedItems.Sum(x=>x.Price) %></strong></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <%if (orderedItems.Select(x => x.ActiveStatus).FirstOrDefault() == "Order Cancel" || orderedItems.Select(x => x.ActiveStatus).FirstOrDefault() == "Send for Delivery")
                                                         { %>
                    <%}
                        else
                        { %>
                    <asp:Button ID="btnsave" runat="server" class="btn btn-primary" Text="Send for Delivery" OnClick="btnsave_Click" />

                    <%} %>
                    <%if (orderedItems.Select(x => x.ActiveStatus).FirstOrDefault() != "Order Cancel")
                                                         { %>
                    <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" /><%}
                                                                                                                                 else
                                                                                                                                 {%>
                    <%} %>
                    <div class="text-center m-t-15">
                        <asp:Label ID="lblMessage" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $('#printInvoice').click(function () {
            Popup($('.invoice')[0].outerHTML);
            function Popup(data) {
                window.print();
                return true;
            }
        });
    </script>
</asp:Content>