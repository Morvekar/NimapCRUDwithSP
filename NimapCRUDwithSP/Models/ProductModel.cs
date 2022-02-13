using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NimapCRUDwithSP.Models
{
    public class ProductModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }
    }
}