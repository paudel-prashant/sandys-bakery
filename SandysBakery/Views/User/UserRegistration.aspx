<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="SandysBakery.Views.User.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
            <h4 class="card-title">User Registration</h4>

            <div class="form-group">
                <label for="txtFirstName">First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server"
                        ErrorMessage="First name is required." ForeColor="Red"
                        ControlToValidate="txtFirstName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <label for="txtMiddleName">Middle Name</label>
                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtLastName">Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                        ErrorMessage="Last name is required." ForeColor="Red"
                        ControlToValidate="txtLastName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <label for="txtEmail">Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                        ErrorMessage="Email address is required." ForeColor="Red"
                        ControlToValidate="txtEmail" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Please provide valid email address." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group">
                <label for="txtPassword">Choose a Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                        ErrorMessage="Password is required." ForeColor="Red"
                        ControlToValidate="txtPassword" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <label for="txtConfirmPassword">Confirm Password</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server"
                        ErrorMessage="Confirm password is required." ForeColor="Red"
                        ControlToValidate="txtConfirmPassword" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                        ErrorMessage="Passwords do not match."
                        ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                        Type="String" Operator="Equal" ForeColor="Red">
                    </asp:CompareValidator>
                </div>
            </div>

            <div class="form-group">
                <label for="txtPhoneNumber">Mobile Number</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" runat="server"
                        ErrorMessage="Phone number is required." ForeColor="Red"
                        ControlToValidate="txtPhoneNumber" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <label for="txtShippingAddress">Shipping Address</label>
                <asp:TextBox ID="txtShippingAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShippingAddress" runat="server"
                        ErrorMessage="Shipping address is required." ForeColor="Red"
                        ControlToValidate="txtShippingAddress" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
           
            <div class="form-group m-0">
                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success btn-lg btn-block" Text="Register Now" OnClick="btnRegister_Click" />
            </div>

            <div class="mt-4 text-center">
                <div class="text-center">Already have an account? <a runat="server" href="~/Views/User/UserLogin.aspx">Sign in</a> </div>
                <div class="text-center m-t-15">
                    <asp:Label ID="lblMessage" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>