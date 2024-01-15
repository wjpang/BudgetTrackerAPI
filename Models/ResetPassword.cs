#pragma warning disable CS8618

namespace BudgetTracker.Models
{
    public class ResetPassword
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}