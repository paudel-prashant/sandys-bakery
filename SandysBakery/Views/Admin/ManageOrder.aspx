<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="SandysBakery.Views.Admin.ManageOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
        <h4 class="card-title" align="center">Manage Orders</h4>
        <div class="form-group">
            <br />
            <div class="well">
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
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%#Eval("ActiveStatus")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Date">
                            <ItemTemplate>
                                <%#Eval("OrderDate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CardNumber">
                            <ItemTemplate>
                                <%#Eval("CardNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnInvoice" class="btn btn-info btn-sm" runat="server" Text="View" CommandArgument='<%# Eval("CartDate")+","+ Eval("UserId")%>' OnClick="btnView_click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    </div>
</asp:Content>