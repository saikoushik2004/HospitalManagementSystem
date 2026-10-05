namespace HospitalManagement.MVC.Models
{
    public class LoginResponse
    {
        public string Message { get; set; } = string.Empty;

        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
