<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="SandysBakery.Views.User.UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
            <h4 class="card-title" align="center">User Details</h4>
            <asp:HiddenField ID="RegistrationId" runat="server" />
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
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
            <div class="form-group">
                <asp:Button ID="btnsave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnsave_Click" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="text-center m-t-15">
                <asp:Label ID="lblMessage" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <br />
            <div class="well">
                <asp:GridView CssClass="table table-bordered" ID="grdUserDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="RegistrationId" OnPageIndexChanging="grdUserDetails_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <%#Eval("FirstName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Middle Name">
                            <ItemTemplate>
                                <%#Eval("MiddleName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <%#Eval("LastName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email Id">
                            <ItemTemplate>
                                <%#Eval("EmailId")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone Number">
                            <ItemTemplate>
                                <%#Eval("PhoneNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shipping Address">
                            <ItemTemplate>
                                <%#Eval("ShippingAddress")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server" class="btn btn-info" Text="Edit" CommandArgument='<%# Eval("RegistrationId")%>' OnClick="btnbtnView_Click" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
    </div>
</asp:Content>