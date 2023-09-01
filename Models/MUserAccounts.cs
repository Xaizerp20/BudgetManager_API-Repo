namespace BudgetManagerAPI.Models
{
    public class MUserAccounts
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNumber { get; set; }
        public bool Active { get; set; } = true; // Valor predeterminado
    }
}
