using BankAccount.models;

namespace BankAccount.views {
    public class AccountView {
        public void ShowAccount(Account account) {
            Console.WriteLine("Name: " + account.Name);
            Console.WriteLine("Password: " + account.Password);
            Console.WriteLine("SSN: " + account.SSN);
            Console.WriteLine("Date of birth: " + account.DateBirth?.ToString("MM/dd/yyyy"));
            Console.WriteLine("Age: " + account.Age + " years old");
            Console.WriteLine("Account type: " + account.AccountType);
            Console.WriteLine("Account ID: " + account.Id);
            Console.WriteLine("ABA number: " + account.ABANumber);
            Console.WriteLine("Creation date: " + account.DateCreation);
            Console.WriteLine("Balance: " + account.Balance.ToString("C2") + "\n");
        }

        public void ShowMaskedAccount(Account account) {
            Console.WriteLine("Name: " + account.Name);
            Console.WriteLine("Password: " + account.Password[0] + new string('*', account.Password.Length - 2) + account.Password[^1]);
            Console.WriteLine("SSN: " + account.SSN[0] + new string('*', account.SSN.Length - 2) + account.SSN[^1]);
            Console.WriteLine("Date of birth: " + account.DateBirth?.ToString("MM/dd/yyyy"));
            Console.WriteLine("Age: " + account.Age + " years old");
            Console.WriteLine("Account type: " + account.AccountType);
            Console.WriteLine("Account ID: " + account.Id[0] + new string('*', account.Id.Length - 2) + account.Id[^1]);
            Console.WriteLine("ABA number: " + account.ABANumber[0] + new string('*', account.ABANumber.Length - 2) + account.ABANumber[^1]);
            Console.WriteLine("Creation date: " + account.DateCreation);
            Console.WriteLine("Balance: " + new string('*', account.Balance.ToString("F2").Length - 3) + account.Balance.ToString("C2")[^3..] + "\n");
        }

        public void ShowDepositPrompt() {
            Console.WriteLine("Enter value you wish to deposit:");
        }

        public void ShowWithdrawalPrompt() {
            Console.WriteLine("Enter value you wish to withdrawal:");
        }

        public double GetMonetaryInput() {
            bool isValid = Double.TryParse(Console.ReadLine(), out double value);
            return isValid ? value : -1;
        }

        public void ShowDepositSuccess(double deposit, double balance) {
            Console.Clear();
            Console.WriteLine("Successfully deposited " + deposit.ToString("C2"));
            Console.WriteLine("\nBalance: " + balance.ToString("C2"));
            Console.WriteLine("\nEnter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowInvalidDeposit() {
            Console.Clear();
            Console.WriteLine("Invalid input for a deposit. A valid deposit is a monetary value, with only numbers, higher than $0.00.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        public void ShowWithdrawalSuccess(double withdrawal, double balance) {
            Console.Clear();
            Console.WriteLine("Successfully withdrew " + withdrawal.ToString("C2"));
            Console.WriteLine("\nBalance: " + balance.ToString("C2"));
            Console.WriteLine("\nEnter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowWithdrawalSuccess(double withdrawal, double balance, double feeRate, string accountType) {
            Console.WriteLine("Successfully withdrawed " + withdrawal.ToString("C2"));
            Console.WriteLine(accountType + " account's " + (feeRate * 100) + "% withdrawal fee: " + (withdrawal * feeRate).ToString("C2"));
            Console.WriteLine("\nBalance: " + balance.ToString("C2"));
            Console.WriteLine("\nEnter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowInvalidWithdrawal(double balance) {
            Console.Clear();
            Console.WriteLine("Invalid value for withdrawal: insufficient funds.");
            Console.WriteLine("\nBalance: " + balance.ToString("C2"));
            Console.WriteLine("\nEnter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowInvalidWithdrawal(double balance, double feeRate, string accountType) {
            Console.Clear();
            Console.WriteLine("Invalid value for withdrawal: insufficient funds. " + accountType + " account's have a " + (feeRate * 100) + "% fee on every withdrawal operation.");
            Console.WriteLine("\nBalance: " + balance.ToString("C2"));
            Console.WriteLine("\nEnter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}