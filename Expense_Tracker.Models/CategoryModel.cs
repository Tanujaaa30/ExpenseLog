using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class CategoryModel
    {
        [Key]
        public int Category_Id { get; set; }

        [Required]  
        public string Name { get; set; }

        //public int Amount { get; set; } 

        [Required]
        public int Limit { get; set; }
    }
}
