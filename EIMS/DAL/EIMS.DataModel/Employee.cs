using System;

namespace EIMS.DataModel
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public DateTimeOffset OnboardDate { get; set; }

        public string Title { get; set; }

        public int ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        public string Comments { get; set; }
    }
}