# Bank Account
This is a console-based bank account management system written in C# that allows users to create different types of accounts (savings, current, teen) and perform various operations on their accounts, such as depositing, withdrawing, checking balance, changing/creating other accounts and more.

## Features
### **Account Management**:
  - Create Teen/Savings/Current accounts with age validation
  - Secure login with SSN and password authentication
  - View account details with sensitive data masking
  - Automatic account type assignment for underage users

### **Financial Operations**:
  - Deposit funds with immediate balance update
  - Type-specific withdrawals:
    - Teen: 2% fee + $50 limit
    - Savings: 3% fee + 15% interest on balances >$1000 after 10 withdrawals
    - Current: 5% fee
  - Real-time balance tracking with currency formatting

### **Security**:
  - Password complexity enforcement (8+ chars, mixed case, special chars)
  - Input validation for SSN (9 digits), dates (MM/DD/YYYY), and names
  - Console masking for passwords and financial inputs

## Technical Details
The project is structured into four main entities: Account, SavingsAccount, CurrentAccount and TeenAccount. Account is an abstract entity that serves as the base for all account types and contains common attributes and methods, such as Deposit and Withdraw. The other three classes inherit from Account and have their own unique attributes and methods.

The program uses object-oriented programming principles, such as inheritance and polymorphism, to manage different types of accounts. User input is validated with regular expressions to ensure that it meets certain requirements, such as having a minimum password length and containing at least one uppercase letter and one special character.

## Architecture
The project follows the Model-View-Controller (MVC) architecture:

### Models:
- Account
- SavingsAccount
- CurrentAccount
- TeenAccount

### Views:
- AccountView
- SavingsAccountView
- CurrentAccountView
- TeenAccountView

### Controllers:
- AccountController
- SavingsAccountController
- CurrentAccountController
- TeenAccountController

## Usage
To use the program, follow the instructions:
1. [Install .NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
1. Open a terminal/command prompt and navigate to the folder in which you'd like to create the app
2. `git clone https://github.com/matheusrocha-mus/Bank-Account.git`
3. `cd bank_account`
4. `dotnet run`

Upon starting the program, the user will be prompted to log in with an existing account or create a new account. Once logged in, the user can perform various operations on their account, such as depositing funds, withdrawing funds and checking their balance.

## Possible Developments
### Design Patterns:
- **DAO**: data is not stored in any way between project reruns. We could use DAOs to handle data write-read operations when the prototype evolves to a version that includes data persistency.
- **Singleton**: multiple account management responsibilities scattered through `Program.cs`. We could create a `AccountManager` class to set a single instance of account and consequently centralizes all account operations (auth, creation, updates).
- **Factory Method**: account creation logic is embedded in `Program.cs` with complex conditional checks. To fix this we can create an `AccountFactory` hierarchy, in which we separate creation logic for Teen/Savings/Current accounts.
- **Command**: fund transaction operations are tightly coupled with UI handling. We could create command objects like `DepositCommand` and `WithdrawalCommand` to decouple operation execution from UI.
- **Chain of Responsability**: there is input validation for basically every user input, but it is scattered across `Program.cs`. We can create validation handlers (`PasswordValidator`, `SSNValidator`, etc.) to centralize validation logic.

### Features:
- Transfer funds between accounts (opt: different fees for different types of accounts)
- Display history of operations
- Savings account interest system operating on time instead of quantity of operations (monthly balance, for example)
- Password reset
- Account login after too many login attempts

## Contributing
Contributions to this project are welcome! If you notice any bugs or would like to suggest an improvement, please create an issue or submit a pull request.

## Credits
Matheus Caetano Rocha