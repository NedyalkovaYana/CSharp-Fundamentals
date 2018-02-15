
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public BankAccount()
        {
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public BankAccount(int id, decimal balance)
        {
            this.Id = id;
            this.Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account {this.Id}, balance {this.Balance}";
        }
    }


