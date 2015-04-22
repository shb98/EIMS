using System;
using System.ComponentModel.DataAnnotations;

namespace Host.IIS.Models
{
    public class EmployeeProfileViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        public string MobilePhone { get; set; }

        public string Title { get; set; }

        public string Department { get; set; }
    }
}