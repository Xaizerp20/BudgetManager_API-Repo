namespace BudgetManagerAPI.Models
{
    public class MExpensesRegister
    {
        public int ExpenseId { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}

