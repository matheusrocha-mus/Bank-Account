using BankAccount.models;
using BankAccount.views;

namespace BankAccount.controllers {
    public class AccountController {
        protected Account account;
        protected AccountView view;

        public AccountController(Account account, AccountView view) {
            this.account = account;
            this.view = view;
        }

        public void ShowAccount() {
            view.ShowAccount(account);
        }

        public void ShowMaskedAccount() {
            view.ShowMaskedAccount(account);
        }

        public void Deposit() {
            view.ShowDepositPrompt();
            double deposit = view.GetMonetaryInput();
            if (deposit > 0) {
                account.Balance += deposit;
                view.ShowDepositSuccess(deposit, account.Balance);

            } else view.ShowInvalidDeposit();
        }

        public virtual void Withdrawal() {
            view.ShowWithdrawalPrompt();
            double withdrawal = view.GetMonetaryInput();
            if (withdrawal > 0 && withdrawal <= account.Balance) {
                account.Balance -= withdrawal;
                view.ShowWithdrawalSuccess(withdrawal, account.Balance);

            } else view.ShowInvalidWithdrawal(account.Balance);
        }
    }
}