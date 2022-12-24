<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="CartItems.aspx.cs" Inherits="SandysBakery.Views.User.CartItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
        <h4 class="card-title" align="center">Items in Cart</h4>
            <div class="form-group">
            <asp:GridView CssClass="table table-bordered" ID="grdcart" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CartId" ShowFooter="true" OnPageIndexChanging="grdcart_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%#Eval("ItemName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <%#Eval("Quantity")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <%# String.Format("{0:0.00}",Eval("SellingPrice"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <%# Eval("AddDate","{0:dd/MM/yyyy}")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" class="btn btn-danger" Text="Remove" CommandArgument='<%# Eval("CartId")%>' CausesValidation="false" OnClick="btnDelete_click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%if (isExist)
                {%>
            <br />
            <ul class="list-group">
                <li class="list-group-item">
                    <asp:DropDownList ID="ddlPaymentOption" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPaymentOption_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPaymentOption" runat="server"
                        ErrorMessage="Payment option is required." ForeColor="Red"
                        ControlToValidate="ddlPaymentOption" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </li>
                <li class="list-group-item">
                    <asp:DropDownList ID="ddlPaymentType" CssClass="form-control" runat="server" Visible="false"></asp:DropDownList>
                    <asp:Label ID="lblmessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </li>
            </ul>
            <div class="text-right">
                <asp:Button ID="btnsave" runat="server" class="btn btn-primary" Text="Order Now" OnClick="btnsave_Click" />
            </div>
            <br />
            <%} %>
        </div>
    </div>
        </div>
</asp:Content>
