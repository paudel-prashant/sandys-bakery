<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserPaymentOptions.aspx.cs" Inherits="SandysBakery.Views.User.UserPaymentOptions" %>

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

        .signup-form {
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
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
        <h4 class="card-title" align="center">Payment Options</h4>

                            <div class="form-group">
                                <label for="txtCardNumber">Card Number</label>
                                <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCardNumber" runat="server"
                                    ErrorMessage="Card number is required." ForeColor="Red"
                                    ControlToValidate="txtCardNumber" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                            <asp:HiddenField ID="HdPaymentGetwayId" runat="server" />


                            <div class="form-group">
                                <label for="txtExpiryDate">Expiry Date</label>
                                <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorExpiryDate" runat="server"
                                    ErrorMessage="Expiry date is required." ForeColor="Red"
                                    ControlToValidate="txtExpiryDate" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>


               
                    <div class="form-group">
                        <label for="txtNameOnCard">Card Name</label>
                        <asp:TextBox ID="txtNameOnCard" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCardName" runat="server"
                            ErrorMessage="Card name is required." ForeColor="Red"
                            ControlToValidate="txtNameOnCard" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
              
                
                    <div class="form-group">
                        <label for="txtSecurityCode">Security Code</label>
                        <asp:TextBox ID="txtSecurityCode" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSecurityCode" runat="server"
                            ErrorMessage="Security code is required." ForeColor="Red"
                            ControlToValidate="txtSecurityCode" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
               
              
                    <div class="form-group">
                        <label for="txtPostalCode">Postal Code</label>
                        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPostalCode" runat="server"
                            ErrorMessage="Postal code is required." ForeColor="Red"
                            ControlToValidate="txtPostalCode" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
               
              
                    <div class="form-group">
                        <label for="ddlPaymentOption">Card Type</label>
                        <asp:DropDownList ID="ddlPaymentOption" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlCardType" runat="server"
                            ErrorMessage="Card type is required." ForeColor="Red"
                            ControlToValidate="ddlPaymentOption" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                
                <div class="form-group">
                    <asp:Button ID="btnPaymentOption" runat="server" CssClass="btn btn-success btn-lg btn-block" Text="Add" OnClick="btnPaymentOption_Click" />
                </div>
                <div class="text-center m-t-15">
                    <asp:Label ID="lblMessage" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
           
            <br />
            <div class="well">
                <asp:GridView CssClass="table table-bordered" ID="grdPayoption" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="PaymentGatewayId" OnPageIndexChanging="grdPayoption_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Card Number">
                            <ItemTemplate>
                                <%#Eval("CardNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("CardName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Security Code">
                            <ItemTemplate>
                                <%#Eval("SecurityCode")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Card Type">
                            <ItemTemplate>
                                <%#Eval("StatusName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expiry Date">
                            <ItemTemplate>
                                <%#Eval("ExpiryDate","{0:dd/MM/yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server" class="btn btn-info" Text="Edit" CommandArgument='<%# Eval("PaymentGatewayId")%>' OnClick="btnbtnView_Click" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
             </div>
        </div>
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtExpiryDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            });
        });
    </script>
</asp:Content>
