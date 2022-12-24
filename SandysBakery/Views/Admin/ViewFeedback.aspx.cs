using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.Admin
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        IAdministrator administrator; 
        public ViewFeedback()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            DataTable dataTable = administrator.FeedBackList();
            grdFeedBack.DataSource = dataTable;
            grdFeedBack.DataBind();
        }

        protected void grdFeedBack_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFeedBack.PageIndex = e.NewPageIndex;
            this.LoadGrid();
        }
    }
}