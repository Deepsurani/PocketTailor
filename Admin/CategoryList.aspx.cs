using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Services;

namespace WebApplication1.Admin
{
    public partial class CategoryList : System.Web.UI.Page
    {
        private readonly ICategoryService CatService;

        public CategoryList()
        {
            CatService=new CategoryService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var data= CatService.GetAll();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Del")
            {
                string row=CatService.Delete(Convert.ToInt32(e.CommandArgument.ToString()));

                Response.Write("<script>alert('" + row + "');");
            }
        }
    }
}