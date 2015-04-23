namespace Host.IIS.Models
{
    public class CreateNewUserModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public int DepartmentId { get; set; }

        public string Title { get; set; }
    }
}