using Expense_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Expense_Tracker.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        [Route("newcategory")]
        public ActionResult Addcategory()
        {
            return View();
        }

        [Route("createcategory")]
        [HttpPost]
        public ActionResult Addcategory(CategoryModel C)
        {
            if (ModelState.IsValid)
            {
                db.category.Add(C);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data inserted')</script>";
                    return RedirectToAction("CategoryList");
                    //ModelState.Clear();

                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data inserted')</script>";
                }
            }
            return View();
        }

        [Route("editcategory")]
        public ActionResult EditCategory(int id)
        {
            var row = db.category.Where(model => model.Category_Id == id).FirstOrDefault();

            return View(row);
        }



        [Route("savecategory")]
        [HttpPost]
        public ActionResult Editcategory(CategoryModel C)
        {
            db.Entry(C).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Data Updated')</script>";
                return RedirectToAction("CategoryList");
            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('Data not Updated')</script>";
            }

            return View();
        }




        ExpenseContext db = new ExpenseContext();
        [Route("categories")]
        public ActionResult Categorylist()
        {
            var data = db.category.ToList();
            return View(data);
        }






        [Route("deletecategory")]
        public ActionResult DeleteCategory(int id)
        {
            if (id > 0)
            {
                var del = db.category.Where(model => model.Category_Id == id).FirstOrDefault();
                if (del != null)
                {
                    db.Entry(del).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted.')";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Found.')";
                    }
                }
            }
            return RedirectToAction("Categorylist");

        }


    }
}