using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Host.IIS.Models
{
    public class AddUserModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public int DepartmentId { get; set; }
    }
}