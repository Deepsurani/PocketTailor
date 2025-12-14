using PocketTailor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Services;

namespace WebApplication1.Admin
{
    public partial class CategoryForm : System.Web.UI.Page
    {
        private readonly ICategoryService Db;
        private readonly CategoryModel Model;
        public CategoryForm()
        {
            Db = new CategoryService();
            Model = new CategoryModel();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BttnInsert_Click(object sender, EventArgs e)
        {
            string message = "";
            string path = "";
            if (Request.QueryString["Edit"] != null)
            {
                message = Db.Update(new CategoryModel
                {
                    CateName = txtCategory.Text,
                    Icon = path,
                    IsActive = Convert.ToBoolean(Status.Text)
                }, Convert.ToInt32(Request.QueryString["Edit"]));
            }
            else
            {
                message = Db.Insert(new CategoryModel()
                {
                    CateName = txtCategory.Text,
                    Icon = path,
                    IsActive = Convert.ToBoolean(Status.Text)
                });
            }

            if (message == "success" || message == "Update")
            {
                alert.InnerHtml = $@"<div class='alert alert-subtle-success alert-dismissible fade show mt-3' role='alert'>
                       {HttpUtility.HtmlEncode(message == "success" ? Messages.Insert : Messages.Update)}
                        <button type='button' class='btn-close' data-bs-dismiss='alert'></button>
                     </div>";
            }
            else
            {
                alert.InnerHtml = $@"<div class='alert alert-subtle-danger alert-dismissible fade show mt-3' role='alert'>
         {HttpUtility.HtmlEncode(message)}
         <button type='button' class='btn-close' data-bs-dismiss='alert'></button>
      </div>";
            }

        }

    }
}