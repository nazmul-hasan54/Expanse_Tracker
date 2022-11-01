using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace expanse_Tracker.Models
{
    public class Expanses
    {
        
        public int ExpansesId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Column(TypeName = "money")]
        public Decimal Amount { get; set; }
        [ForeignKey("ExpenseCategory")]
        public int CategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}
