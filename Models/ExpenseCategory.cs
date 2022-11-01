using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using expanse_Tracker.Models;

namespace expanse_Tracker.Models
{
    
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual IList<Expanses> Expanses { get; set; }
    }
    
}
