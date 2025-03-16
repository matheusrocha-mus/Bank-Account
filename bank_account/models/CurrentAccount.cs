namespace BankAccount.models {
    public class CurrentAccount : Account {
        public CurrentAccount(string name, string password, string ssn, DateTime? dateBirth)
        : base(name, password, ssn, dateBirth) {
            AccountType = "Current";
        }
    }
}