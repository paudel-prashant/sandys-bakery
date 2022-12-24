using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.Admin
{
    public partial class ProductCategory : System.Web.UI.Page
    {
        IAdministrator administrator;
        public ProductCategory()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListGridCategories();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MessageReturnType messageReturnType = new MessageReturnType();
                ProductCategories productCategories = new ProductCategories();
                productCategories.CategoryName = txtCategoryName.Text;

                if (ProductCategoryId.Value == "")
                {
                    messageReturnType = administrator.AddCategory(productCategories);
                }
                else
                {
                    productCategories.ProductCategoriesId = Convert.ToInt32(ProductCategoryId.Value);
                    messageReturnType = administrator.EditCategory(productCategories);
                }
                lblMessage.Visible = true;
                if (messageReturnType.IsSuccess)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);
                    txtCategoryName.Text = "";
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
        private void ListGridCategories()
        {
            grdCategory.DataSource = administrator.ProductCategoriesList();
            grdCategory.DataBind();
        }
        protected void btnbtnView_Click(object sender, EventArgs e)
        {
            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            ProductCategories productCategories = new ProductCategories();
            productCategories = administrator.GetProductCategoryById(id);
            ProductCategoryId.Value = Convert.ToString(productCategories.ProductCategoriesId);
            txtCategoryName.Text = productCategories.CategoryName;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, false);
        }

        protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategory.PageIndex = e.NewPageIndex;
            this.ListGridCategories();
        }
    }
}