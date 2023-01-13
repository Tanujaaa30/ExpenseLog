using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class ExpenseModel
    {
        [Key]
        public int Expense_Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        
         public string Category { get; set; }  

        //[Display(Name="CategoryModel")]
        //public int? Category_Id { get; set; }

        
        //[ForeignKey("Category_Id")]
        //public virtual CategoryModel Category { get; set; }


        //[Display(Name = "Monthly_Budget")]
        //public int? Budget_Id { get; set; }

        //[ForeignKey("Budget_Id")]
        //public virtual Monthly_Budget Budget { get; set; }


    }
}
