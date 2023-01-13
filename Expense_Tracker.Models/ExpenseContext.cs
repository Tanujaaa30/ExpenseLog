using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Expense_Tracker.Models
{
    public class ExpenseContext : DbContext
    {

        public DbSet<ExpenseModel> expense {get; set;}
        public DbSet<CategoryModel> category { get; set; }
        public DbSet<Monthly_Budget> monthly_budget { get; set; }
    }
}
