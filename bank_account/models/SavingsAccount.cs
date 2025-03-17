namespace BankAccount.models {
    public class SavingsAccount : Account {
        public SavingsAccount(string name, string password, string ssn, DateTime? dateBirth)
        : base(name, password, ssn, dateBirth) {
            AccountType = "Savings";
        }
    }
}