<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserOrders.aspx.cs" Inherits="SandysBakery.Views.User.UserOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
        <h4 class="card-title" align="center">Ordered Items</h4>
        <div class="card-body">
             <div class="form-group">
                <asp:GridView CssClass="table table-bordered" ID="grdUserOrder" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grdUserOrder_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Item Name">
                            <ItemTemplate>
                                <%#Eval("ItemName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <%#Eval("TotalOrderQuantity")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <%#Eval("Price")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Payment">
                            <ItemTemplate>
                                <%#Eval("StatusName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Date">
                            <ItemTemplate>
                                <%#Eval("OrderDate","{0:dd/MM/yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CardNumber">
                            <ItemTemplate>
                                <%#Eval("CardNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate >
                              <asp:LinkButton ID="btnCancel" runat="server" class="btn btn-danger btn-sm" Text="Cancel" Visible='<%# Eval("ActiveStatus").ToString() ==  "Ordered and Not Paid" ? true : false %>' CommandArgument='<%# Eval("OrderId")%>' CausesValidation="false" OnClick="btnCancel_click" />
                                 <asp:Label runat="server" Visible='<%# Eval("ActiveStatus").ToString() ==  "Ordered and Not Paid" ? false : true %>' Text="Ordered"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Invoice">
                            <ItemTemplate >
                              <asp:LinkButton ID="btnInvoice" class="btn btn-info btn-sm" runat="server" Text="View"  CommandArgument='<%# Eval("CartDate")%>' OnClick="btnView_click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
        </div>
</asp:Content>