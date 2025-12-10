using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocketTailor.Model
{
    public class CategoryModel
    {
        public int CateID { get; set; }
        public string CateName { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}