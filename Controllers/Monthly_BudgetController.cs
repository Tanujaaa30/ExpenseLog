using Expense_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Expense_Tracker.Controllers
{
    public class Monthly_BudgetController : Controller
    {
        [Route("addbudget")]
        // GET: Total_Expense
        public ActionResult AddBudget()
        {
            return View();
        }

        [Route("createmonthlybudget")]
        [HttpPost]
        public ActionResult AddBudget(Monthly_Budget M)
        {
            if (ModelState.IsValid)
            {
                db.monthly_budget.Add(M);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data inserted')</script>";
                    return RedirectToAction("Budgetlist");
                    //ModelState.Clear();

                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data inserted')</script>";
                }
            }
            return View();
        }



        [Route("editmonthlybudget")]
        public ActionResult EditMonthlyBudget(int id)
        {
            var row = db.monthly_budget.Where(model => model.Budget_Id == id).FirstOrDefault();

            return View(row);
        }



        [Route("savemonthlybudget")]
        [HttpPost]
        public ActionResult EditMonthlyBudget(Monthly_Budget M)
        {
            db.Entry(M).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Data Updated')</script>";
                return RedirectToAction("BudgetList");
            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('Data not Updated')</script>";
            }


            return View();
        }








        [Route("deletebudget")]
        public ActionResult DeleteBudget(int id)
        {
            if (id > 0)
            {
                var del = db.monthly_budget.Where(model => model.Budget_Id == id).FirstOrDefault();
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
            return RedirectToAction("Budgetlist");

        }









        ExpenseContext db = new ExpenseContext();
        [Route("budget")]
        // GET: Total_Expense
        public ActionResult Budgetlist()
        {
            var data = db.monthly_budget.ToList();
            return View(data);
        }
    }
}