namespace BankAccount.views {
    public class TeenAccountView : AccountView {
        public void ShowInvalidWithdrawal() {
            Console.WriteLine("Invalid value for withdrawal: only widrawals below $50.00 are allowed for Teen accounts.");
            Console.WriteLine("\nEnter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}