using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class Monthly_Budget
    {
        [Key]
        public int Budget_Id { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public int Budget { get; set; } 
    }
}
