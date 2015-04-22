namespace EIMS.Data
{
    public class SalaryReport
    {
        public int SalaryReportId { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal OtAllowance { get; set; }

        public decimal TrafficAllowance { get; set; }

        public decimal TotalGross { get; set; }

        public decimal VacationDeduct { get; set; }

        public decimal InsuranceDeduct { get; set; }

        public decimal TotalDeduct { get; set; }

        public decimal TotalNetPay { get; set; }

        public string Comments { get; set; }
    }
}