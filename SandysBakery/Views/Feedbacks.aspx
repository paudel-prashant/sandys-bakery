<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Feedbacks.aspx.cs" Inherits="SandysBakery.Views.Feedbacks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .form-control {
            height: 40px;
            box-shadow: none;
            color: #969fa4;
        }

        .form-control:focus {
            border-color: #5cb85c;
        }

        .form-control, .btn {
            border-radius: 3px;
        }

        .signup-form {
            width: 500px;
            margin: 0 auto;
            padding: 30px 0;
        }

        .signup-form h2 {
            color: #636363;
            margin: 0 0 15px;
            position: relative;
            text-align: center;
        }

        .signup-form h2:before, .signup-form h2:after {
            content: "";
            height: 2px;
            width: 30%;
            background: #d4d4d4;
            position: absolute;
            top: 50%;
            z-index: 2;
        }

        .signup-form h2:before {
            left: 0;
        }

        .signup-form h2:after {
            right: 0;
        }

        .signup-form .hint-text {
            color: #999;
            margin-bottom: 30px;
            text-align: center;
        }

        .signup-form  {
            color: #999;
            border-radius: 3px;
            margin-bottom: 15px;
            background: #f2f3f7;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            padding: 30px;
        }

        .signup-form .form-group {
            margin-bottom: 20px;
        }

        .signup-form input[type="checkbox"] {
            margin-top: 3px;
        }

        .signup-form .btn {
            font-size: 16px;
            font-weight: bold;
            min-width: 140px;
            outline: none !important;
        }

        .signup-form .row div:first-child {
            padding-right: 10px;
        }

        .signup-form .row div:last-child {
            padding-left: 10px;
        }

        .signup-form a {
            color: #fff;
            text-decoration: underline;
        }

            .signup-form a:hover {
                text-decoration: none;
            }

        .signup-form form a {
            color: #5cb85c;
            text-decoration: none;
        }

        .signup-form form a:hover {
            text-decoration: underline;
        }
    </style>

    <div class="signup-form">
        <h2>Feedback</h2>        
        <div class="form-group">
            <label for="txtPhoneNo">Full Name</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFullName" runat="server"
                ErrorMessage="Full Name is required." ForeColor="Red"
                ControlToValidate="txtFullName" Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                ErrorMessage="Email is required." ForeColor="Red"
                ControlToValidate="txtEmail" Display="Dynamic">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="Invalid Email" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="txtComment">Feedback</label>
            <asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFeedback" runat="server"
                ErrorMessage="Feedback is required." ForeColor="Red"
                ControlToValidate="txtComment" Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success btn-lg btn-block" Text="Post" OnClick="btnRegister_Click" />
        </div>
    </div>
</asp:Content>