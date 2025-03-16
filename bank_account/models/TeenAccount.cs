namespace BankAccount.models {
    public class TeenAccount : Account {
        public TeenAccount(string name, string password, string ssn, DateTime? dateBirth)
        : base(name, password, ssn, dateBirth) {
            AccountType = "Teen";
        }
    }
}