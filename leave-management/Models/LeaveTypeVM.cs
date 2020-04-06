using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Type of Leave")]
        public string Name { get; set; }
        [Display(Name = "Date Created")]

        public DateTime? DateCreated { get; set; }
    }

   
}
