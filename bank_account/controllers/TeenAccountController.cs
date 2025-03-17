using BankAccount.models;
using BankAccount.views;

namespace BankAccount.controllers {
    public class TeenAccountController : AccountController {
        private TeenAccount _teenAccount;
        private TeenAccountView _teenAccountView;

        private const double _withdrawalFee = 0.02;
        private const double _maximumWithdrawal = 50;

        public TeenAccountController(TeenAccount account, TeenAccountView view)
            : base(account, view) {
            _teenAccount = account;
            _teenAccountView = view;
        }

        public override void Withdrawal() {
            _teenAccountView.ShowWithdrawalPrompt();
            double withdrawal = _teenAccountView.GetMonetaryInput();

            if (withdrawal > 0 && withdrawal <= _teenAccount.Balance) {
                if (_teenAccount.Balance < withdrawal * (1 + _withdrawalFee)) {
                    _teenAccountView.ShowInvalidWithdrawal(_teenAccount.Balance, _withdrawalFee, "Teen");
                }

                else if (withdrawal >= _maximumWithdrawal) {
                    _teenAccountView.ShowInvalidWithdrawal();
                }

                else {
                    _teenAccount.Balance -= withdrawal * (1 + _withdrawalFee);
                    _teenAccountView.ShowWithdrawalSuccess(withdrawal, _teenAccount.Balance, _withdrawalFee, "Teen");
                }

            } else _teenAccountView.ShowInvalidWithdrawal(_teenAccount.Balance);
        }
    }
}