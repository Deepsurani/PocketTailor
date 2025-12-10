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
            string path = "";
            string message = Db.Insert(new CategoryModel()
            {
                CateName = txtCategory.Text,
                Icon = path,
                IsActive = Convert.ToBoolean(Status.Text)
            });
            if (message == "error" || message == "Dublicat")
            {
                alert.InnerHtml = $@"<div class='alert alert-subtle-danger alert-dismissible fade show mt-3' role='alert'>
         {HttpUtility.HtmlEncode(message == "error" ? Messages.Error : Messages.Duplicate)}
         <button type='button' class='btn-close' data-bs-dismiss='alert'></button>
      </div>";

            }
            else if (message == "success" || message == "Update")
            {
                alert.InnerHtml = $@"<div class='alert alert-subtle-success alert-dismissible fade show mt-3' role='alert'>
                       {HttpUtility.HtmlEncode(message == "success" ? Messages.Insert : Messages.Update)}
                        <button type='button' class='btn-close' data-bs-dismiss='alert'></button>
                     </div>";
            }

        }

    }
}