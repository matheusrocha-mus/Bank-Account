namespace BankAccount.models {
    public abstract class Account {
        private static int _lastId = 0;
        private static int _lastAba = 0;

        private string _id;
        private string _name;
        private string _password;
        private string _ssn;
        private DateTime? _dateBirth;
        private int _age;
        private string _accountType;
        private string _abaNumber;
        private DateTime _dateCreation;
        private double _balance;

        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string SSN { get; set; }
        public DateTime? DateBirth { get; set; }
        public int Age { get; set; }
        public string AccountType { get; protected set; }
        public string ABANumber { get; set; }
        public DateTime DateCreation { get; set; }
        public double Balance { get; set; }

        private static string GenerateAccountID(int lastId) {
            _lastId++;
            return _lastId.ToString("D12");
        }

        private static string GenerateABANumber(int lastAba) {
            _lastAba++;
            return _lastAba.ToString("D9");
        }

        public Account(string name, string password, string ssn, DateTime? dateBirth) {
            Id = GenerateAccountID(_lastId);

            Name = name;
            Password = password;
            SSN = ssn;
            DateBirth = dateBirth;
            Age = (int)((DateTime.Now - (dateBirth ?? DateTime.MinValue)).TotalDays / 365.25);
            ABANumber = GenerateABANumber(_lastAba);
            DateCreation = DateTime.Now;
            Balance = 0.00;
        }
    }
}