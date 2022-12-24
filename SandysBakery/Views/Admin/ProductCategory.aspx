<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="ProductCategory.aspx.cs" Inherits="SandysBakery.Views.Admin.ProductCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
            <h4 class="card-title" align="center">Product Categories</h4>
        
        <div class="form-group">
            <div class="container">
                <asp:HiddenField ID="ProductCategoryId" runat="server" />
                <div class="form-group">
                    <label for="txtCategoryName">Category Name:</label>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryName" runat="server"
                        ErrorMessage="Category Name is required" ForeColor="Red"
                        ControlToValidate="txtCategoryName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnsave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click"  />
                <div class="text-center m-t-15">
                    <asp:Label ID="lblMessage" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <br />
            <div class="form-group">
                <asp:GridView CssClass="table table-bordered" ID="grdCategory" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ProductCategoriesId" OnPageIndexChanging="grdCategory_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Category Name">
                            <ItemTemplate>
                                <%#Eval("CategoryName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
                         <asp:TemplateField >
                            <ItemTemplate>
                                 <asp:LinkButton   ID="btnView"  runat="server" class="btn btn-info" Text="Edit"  CommandArgument='<%# Eval("ProductCategoriesId")%>' OnClick="btnbtnView_Click"   CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
