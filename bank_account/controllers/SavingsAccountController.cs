using BankAccount.models;
using BankAccount.views;

namespace BankAccount.controllers {
    public class SavingsAccountController : AccountController {
        private SavingsAccount _savingsAccount;
        private SavingsAccountView _savingsAccountView;

        private const double _interestRate = 0.15;
        private const double _withdrawalFee = 0.03;
        private const int _requiredWithdrawalsQuant = 10;
        private static int _withdrawalsCounter = 0;

        public SavingsAccountController(SavingsAccount account, SavingsAccountView view)
            : base(account, view) {
            _savingsAccount = account;
            _savingsAccountView = view;
        }

        public override void Withdrawal() {
            _savingsAccountView.ShowWithdrawalPrompt();
            double withdrawal = _savingsAccountView.GetMonetaryInput();

            if (withdrawal > 0 && withdrawal <= _savingsAccount.Balance) {
                if (_savingsAccount.Balance < withdrawal * (1 + _withdrawalFee)) {
                    _savingsAccountView.ShowInvalidWithdrawal(_savingsAccount.Balance, _withdrawalFee, "Savings");
                }

                else {
                    _savingsAccount.Balance -= withdrawal * (1 + _withdrawalFee);
                    _withdrawalsCounter++;
                    _savingsAccountView.ShowWithdrawalSuccess(withdrawal, _savingsAccount.Balance, _withdrawalFee, "Savings");

                    if (_savingsAccount.Balance > 1000 && _withdrawalsCounter > _requiredWithdrawalsQuant) {
                        _savingsAccount.Balance *= 1 + _interestRate;
                        _withdrawalsCounter = 0;
                        _savingsAccountView.ShowInterestRate(_savingsAccount.Balance, _interestRate, _requiredWithdrawalsQuant);
                    }
                }

            } else _savingsAccountView.ShowInvalidWithdrawal(_savingsAccount.Balance);
        }
    }
}