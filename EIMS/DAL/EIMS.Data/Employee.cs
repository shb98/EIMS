﻿using System;

namespace EIMS.Data
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTimeOffset? Birthday { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Title { get; set; }

        public virtual Department Department { get; set; }
    }
}