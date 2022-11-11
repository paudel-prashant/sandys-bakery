<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="SandysBakery.Views.User.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-4 mx-auto">
        <div class="card card-body mb-2">
            <h4 class="card-title">Login</h4>
            <div class="form-group">
                <label for="txtUserName">Enter Username</label>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server"
                        ErrorMessage="UserName is required" ForeColor="Red"
                        ControlToValidate="txtUserName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>

            </div>

            <div class="form-group">
                <label for="txtPassword">
                    Enter Password
                </label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                        ErrorMessage="Password is required" ForeColor="Red"
                        ControlToValidate="txtPassword" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group m-0">
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Sign In" OnClick="btnLogin_Click" />
            </div>
            <div class="mt-4 text-center">
                Don't have an account? <a runat="server" href="~/Views/User/UserRegistration.aspx">Create One</a>
            </div>
        </div>
    </div>
</asp:Content>
