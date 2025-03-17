namespace BankAccount.views {
    public class SavingsAccountView : AccountView {
        public void ShowInterestRate(double balance, double interestRate, int requiredWithdrawalsQuant) {
            Console.WriteLine("Savings account's " + (interestRate * 100) + "% interest rate on balances over $1,000.00: " + (balance * interestRate).ToString("C2") + " after " + requiredWithdrawalsQuant + " withdrawal operations.");
            Console.WriteLine("\nBalance: " + balance.ToString("C2") + " => " + (balance * (1 + interestRate)).ToString("C2"));
            Console.WriteLine("\nEnter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}