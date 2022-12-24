<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="ProductItem.aspx.cs" Inherits="SandysBakery.Views.Admin.ProductItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
        <h4 class="card-title" align="center">Product Items</h4>
        <div class="form-group">
            <div class="container">
                <asp:HiddenField ID="ProductId" runat="server" />
                <asp:HiddenField ID="imagePath" runat="server" />
                <asp:HiddenField ID="FileName" runat="server" />
                <div class="form-group">
                    <label for="ddlCategory">Category Name</label>
                    <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server"
                        ErrorMessage="Category is required." ForeColor="Red"
                        ControlToValidate="ddlCategory" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtProductName">Product Name</label>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" runat="server"
                        ErrorMessage="Product Name is required." ForeColor="Red"
                        ControlToValidate="txtProductName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtSellingPrice">Price(per)</label>
                    <asp:TextBox ID="txtSellingPrice" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSellingPrice" runat="server"
                        ErrorMessage="Selling Price is required." ForeColor="Red"
                        ControlToValidate="txtSellingPrice" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtDescription">Description</label>
                    <asp:TextBox ID="txtDescription" TextMode="multiline" CssClass="form-control" Columns="50" Rows="5" runat="server" />
                </div>
                <div class="form-group">

                    <label for="txtSellingPrice">Image</label>
                    <asp:FileUpload ID="FileUploadImage" runat="server" CssClass="form-control" />

                    <div class='col-sm-4 col-xs-6 col-md-3 col-lg-3'>
                        <asp:Image ID="ImageFile" runat="server" class="img-thumbnail" />
                        <!--<div class='text-right'>
                            <small class='text-muted'>Image Title</small>
                        </div> -->
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
                <asp:GridView CssClass="table table-bordered" ID="grdProduct" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ProductItemsId" OnPageIndexChanging="grdProduct_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Category Name">
                            <ItemTemplate>
                                <%#Eval("CategoryName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <%#Eval("ItemName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price(per)">
                            <ItemTemplate>
                                <%#Eval("SellingPrice")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server" class="btn btn-info" Text="Edit" CommandArgument='<%# Eval("ProductItemsId")%>' OnClick="btnbtnView_Click" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
