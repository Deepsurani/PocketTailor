using PocketTailor.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    interface ICategoryService
    {
        List<CategoryModel> GetByid(int id = 0);
        String Insert(CategoryModel model);
        String Update(CategoryModel model,int id=0);
        String Delete(int id = 0);
        List<CategoryModel> GetAll();
    }
    public class CategoryService : ICategoryService, IDisposable
    {
        private readonly DbConnection db;

        public CategoryService()
        {
            db = new DbConnection();
        }
        public string Delete(int id = 0)
        {
            if (id == 0)
            {
                return Messages.IdIsZero;
            }
            Dictionary<string, object> returnval = db.AddUpdateDeleteData("CategoryDeleteSp", new Dictionary<string, object> {
                { "@Cid", id }
            }, new Dictionary<string, System.Data.SqlDbType>
            {
                {"@Retval",System.Data.SqlDbType.TinyInt }
            });

            if (returnval.ContainsKey("@Retval"))
            {
                if (returnval["@Retval"].ToString() == "3")
                {
                    return Messages.Delete;
                }
                else
                {
                    return Messages.Error;
                }
            }
            else
            {
                return Messages.Error;
            }
        }
        public List<CategoryModel> GetAll()
        {
            Dictionary<string, object> Data = db.GetData("CategorySelectSp");

            if (Data.ContainsKey("Data"))
            {
                DataTable dt= Data["Data"] as DataTable;
                List<CategoryModel> categorylist = new List<CategoryModel>();

                foreach (DataRow row in dt.Rows)
                {
                    CategoryModel category = new CategoryModel
                    {
                        CateID = Convert.ToInt32(row["CategoryId"]),
                        CateName = row["Category"].ToString(),
                        Icon = row["Icon"].ToString(),
                        IsActive = Convert.ToBoolean(row["Status"])
                    };
                    categorylist.Add(category);
                }
                return categorylist;

            }
            else
            {
                return null;
            }

        }

        public List<CategoryModel> GetByid(int id = 0)
        {
            var ResponseData = db.GetData("SPCategorySelect", new Dictionary<string, object>()
            {
                {"@catid",id}
            });

            if (ResponseData.ContainsKey("Data"))
            {
                CategoryModel model = new CategoryModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.CateID = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                    model.CateName = dt.Rows[i]["Category"].ToString();
                    model.Icon = dt.Rows[i]["Icon"].ToString();
                    model.IsActive = Convert.ToBoolean(dt.Rows[i]["Status"].ToString());

                }
              return new List<CategoryModel>() { model };


            }

            else
            {
                return null;
            }

        }

        public string Insert(CategoryModel model)
        {
            if (model==null)
            {
                return Messages.ModelIsNull;
            }
            try
            {
                Dictionary<string, object> returnval = db.AddUpdateDeleteData("CategoryInsertUpdateSp", new Dictionary<string, object>()
                {
                    {"@Category",model.CateName},
                    {"@Icon",model.Icon },
                    {"@Status",model.IsActive}
                },new Dictionary<string, SqlDbType>()
                {
                    { "@Retval",SqlDbType.TinyInt }
                });
                if (returnval.ContainsKey("@Retval"))
                {
                    if (returnval["@Retval"].ToString()=="1")
                    {
                        return "success";
                    }
                    else if (returnval["@Retval"].ToString() == "2")
                    {
                        return "Update";
                    }
                    else
                    {
                        return "Dublicat";
                    }
                }
                else
                {
                    return "error";
                }

            }
            catch (Exception ex)
            {

                return "error";
            }
        }

        public string Update(CategoryModel model,int id=0)
        {
            if (id==0)
            {
                return Messages.IdIsZero; 
            }
            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            try
            {
                Dictionary<string, object> returnval = db.AddUpdateDeleteData("CategoryInsertUpdateSp", new Dictionary<string, object>()
                {
                    {"@Category",model.CateName},
                    {"@Icon",model.Icon },
                    {"@Status",model.IsActive}
                }, new Dictionary<string, SqlDbType>()
                {
                    { "@Retval",SqlDbType.TinyInt }
                });
                if (returnval.ContainsKey("@Retval"))
                {
                    if (returnval["@Retval"].ToString() == "1")
                    {
                        return "success";
                    }
                    else
                    {
                        return "Dublicat";
                    }
                }
                else
                {
                    return "error";
                }

            }
            catch (Exception ex)
            {

                return "error";
            }

        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}