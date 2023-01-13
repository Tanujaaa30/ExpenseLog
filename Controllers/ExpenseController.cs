using Expense_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Expense_Tracker.Controllers
{
    public class ExpenseController : Controller
    {   
        // GET: Expense
        [Route("newexpense")]
        public ActionResult AddExpense()
        {         
            var list = new List<string>() { "Shopping","Food","Maintainence","Vehicle","Education"};
            ViewBag.list = list;
            return View();
        }



        [Route("createexpense")]
        [HttpPost]
        public ActionResult AddExpense(ExpenseModel E)
        {
            if (ModelState.IsValid) { 
            db.expense.Add(E);
            int a = db.SaveChanges();
            if(a>0)
            {
                TempData["InsertMessage"] = "<script>alert('Data inserted')</script>";
                    return RedirectToAction("Expenselist");
            }
            else
            {
                ViewBag.InsertMessage = "<script>alert('Data inserted')</script>";
            }
            }           
            return View();
        }




        [Route("editexpense")]
        public ActionResult EditExpense(int id)
        {
            var list = new List<string>() { "Shopping", "Food", "Maintainence", "Vehicle", "Education" };
            ViewBag.list = list;
            var row = db.expense.Where(model => model.Expense_Id == id).FirstOrDefault();

            return View(row);
        }

        [Route("saveexpense")]
        [HttpPost]
        public ActionResult EditExpense(ExpenseModel E)
        {
            db.Entry(E).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Data Updated')</script>";
                return RedirectToAction("Expenselist");
            }
            else
            {
                //ViewBag.UpdateMessage = "<script>alert('Data not Updated')</script>";
            }

            return View();
        }


        //[Route("deleteexpense")]
        //public ActionResult DeleteExpense(int id)
        //{

        //    var del=db.expense.Where(model=>model.Id == id).FirstOrDefault();
        //    return View(del);
        //}


        [Route("deleteexpense")]
        public ActionResult DeleteExpense(int id)
        {
            if (id > 0)
            {
                var del = db.expense.Where(model=>model.Expense_Id==id).FirstOrDefault();
                if (del!= null)
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
            return RedirectToAction("Expenselist");

        }




        ExpenseContext db = new ExpenseContext();
        [Route("expenses")]
        public ActionResult Expenselist()
        {

            var data = db.expense.ToList();
            return View(data);
        }



        






        
    }
}