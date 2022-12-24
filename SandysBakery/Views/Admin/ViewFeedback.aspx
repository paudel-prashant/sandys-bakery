<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="SandysBakery.Views.Admin.ViewFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-6 mx-auto">
        <div class="card card-body mb-2">
        <h4 class="card-title" align="center">Feedback</h4>
        <div class="form-group">
            <br />
            <div class="well">
                <asp:GridView CssClass="table table-bordered" ID="grdFeedBack" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grdFeedBack_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("FullName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <%#Eval("Email")%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate>
                                <%#Eval("Comment")%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
        </div>
</asp:Content>