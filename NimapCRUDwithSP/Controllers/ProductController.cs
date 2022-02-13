using NimapCRUDwithSP.Models;
using NimapCRUDwithSP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace NimapCRUDwithSP.Controllers
{
    public class ProductController : Controller
    {
        DataAccess dataAccess = new DataAccess();
        // GET: Product
        public ActionResult List(int? i)
        {
            var data = dataAccess.GetProducts();
            return View(data.ToList().ToPagedList(i ?? 1, 10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel prod)
        {
            if (dataAccess.InsertProd(prod))
            {
                
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErMsg"] = "Failed";
            }
            return View();
        }

        public ActionResult Edit(int CategoryID)
        {
            var data = dataAccess.GetProducts().Find(a => a.CategoryID == CategoryID);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel prod)
        {
            if (dataAccess.UpdateProd(prod))
            {
              
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErMsg"] = "Failed";
            }
            return View();
        }

        public ActionResult Delete(int CategoryID)
        {
            int r = dataAccess.DeleteProd(CategoryID);
            if (r > 0)
            {
               
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErMsg"] = "Failed";
            }
            return View();
        }
    }
}