using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Host.IIS.Models
{
    public class EmployeeProfileViewModel
    {
        [Required]
        public string FullName { get; set; }

        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        public string MobilePhone { get; set; }

        public string Title { get; set; }
    }
}