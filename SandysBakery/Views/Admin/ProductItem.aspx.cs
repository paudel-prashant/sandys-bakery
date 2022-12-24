using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.Admin
{
    public partial class ProductItem : System.Web.UI.Page
    {
        IAdministrator administrator;
        public ProductItem()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
                ProductListGrid();
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                MessageReturnType messageReturnType = new MessageReturnType();
                ProductItems productItems = new ProductItems();
                productItems.ProductCategoriesId = Convert.ToInt32(ddlCategory.SelectedValue);
                productItems.ItemName = txtProductName.Text;
                productItems.SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
                productItems.Description = txtDescription.Text;
                if (FileUploadImage.HasFile)
                {
                    string fileName = Guid.NewGuid() + FileUploadImage.PostedFile.FileName;
                    string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    productItems.ImagePath = "~/Images/" + fileName;
                    productItems.FileName = fileName;
                    string extension = Path.GetExtension(fileName);
                    if (extension.ToLower() != ".jpg" && extension.ToLower() != ".png" && extension.ToLower() != ".jpeg")
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Images with extensions .jpg, .png and .jpeg are only allowed.";
                        return;
                    }
                    FileUploadImage.SaveAs(filePath);
                }
                else
                {
                    if (ProductId.Value == "")
                    {

                    }
                    else
                    {
                        productItems.FileName = FileName.Value;
                        productItems.ImagePath = imagePath.Value;
                    }
                }
                if (ProductId.Value == "")
                {
                    messageReturnType = administrator.AddProduct(productItems);
                }
                else
                {
                    productItems.ProductItemsId = Convert.ToInt32(ProductId.Value);
                    messageReturnType = administrator.EditProduct(productItems);
                }
                if (messageReturnType.IsSuccess)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);
                    txtProductName.Text = "";
                    txtSellingPrice.Text = "";
                    Response.Redirect(Request.RawUrl, false);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = messageReturnType.ReturnMessage;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadCategory()
        {
            DataTable dataTable = administrator.ProductCategoriesList();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ProductCategoriesId";
            ddlCategory.DataSource = dataTable;
            ddlCategory.DataBind();
        }
        private void ProductListGrid()
        {
            grdProduct.DataSource = administrator.ProductList();
            grdProduct.DataBind();
        }
        protected void btnbtnView_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            ProductItems productItems = new ProductItems();
            productItems = administrator.GetProductById(id);
            ProductId.Value = Convert.ToString(productItems.ProductItemsId);
            txtProductName.Text = productItems.ItemName;
            txtSellingPrice.Text = productItems.SellingPrice.ToString();
            ddlCategory.SelectedValue = productItems.ProductCategoriesId.ToString();
            ImageFile.ImageUrl = productItems.ImagePath;
            imagePath.Value = productItems.ImagePath;
            txtDescription.Text = productItems.Description;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, false);
        }
        protected void grdProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProduct.PageIndex = e.NewPageIndex;
            this.ProductListGrid();
        }
    }
}