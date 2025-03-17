using BankAccount.models;
using BankAccount.views;

namespace BankAccount.controllers {
    public class CurrentAccountController : AccountController {
        private CurrentAccount _currentAccount;
        private CurrentAccountView _currentAccountView;

        private const double withdrawalFee = 0.05;

        public CurrentAccountController(CurrentAccount account, CurrentAccountView view)
            : base(account, view) {
            _currentAccount = account;
            _currentAccountView = view;
        }

        public override void Withdrawal() {
            _currentAccountView.ShowWithdrawalPrompt();
            double withdrawal = _currentAccountView.GetMonetaryInput();

            if (withdrawal > 0 && withdrawal <= _currentAccount.Balance) {
                if (_currentAccount.Balance < withdrawal * (1 + withdrawalFee)) {
                    _currentAccountView.ShowInvalidWithdrawal(_currentAccount.Balance, withdrawalFee, "Current");
                }

                else {
                    _currentAccount.Balance -= withdrawal * (1 + withdrawalFee);
                    _currentAccountView.ShowWithdrawalSuccess(withdrawal, _currentAccount.Balance, withdrawalFee, "Current");
                }

            } else _currentAccountView.ShowInvalidWithdrawal(_currentAccount.Balance);
        }
    }
}