namespace Host.IIS.Models
{
    public class SearchEmployeeOptions
    {
        // Equal
        public string Email { get; set; }

        // Contains
        public string FullName { get; set; }

        // Equal
        public int? DepartmentId { get; set; }

        // Contains
        public string Title { get; set; }
    }
}