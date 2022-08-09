namespace Code.Smells.Class
{
    public class DataClass
    {
    
    }

    internal class InterestCalculator
    {
        private decimal _interestRate = 1.01m;

        public void CalculateInterest(Account account)
        {
            if (account.AccountType == "Checking")
            {
                return;
            }
            if (account.AccountType == "Savings")
            {
                decimal interest = account.Balance * this._interestRate;
                account.Balance += interest;
                return;
            }
            throw new InvalidOperationException($"Unknown Account Type: {account.AccountType}");
        }
    }
    
    internal class Account
    {
        public int Id { get; set; }
        public string? AccountType { get; set; }
        public decimal Balance { get; set; }
    }

    internal class RefactoredInterestCalculator
    {
        private decimal _interestRate = 1.01m;
        public decimal CalculateInterest(RefactoredAccount refactoredAccount)
        {
            if (refactoredAccount.AccountType == "Checking")
            {
                return 0;
            }
            if (refactoredAccount.AccountType == "Savings")
            {
                decimal interest = refactoredAccount.Balance * this._interestRate;
                return interest;
            }
            throw new InvalidOperationException($"Unknown Account Type: {refactoredAccount.AccountType}");
        }
    }
    
    internal class RefactoredAccount
    {
        public RefactoredAccount(int id, string accountType, decimal balance)
        {
            Id = id;
            AccountType = accountType;
            Balance = balance;
        }
        
        public int Id { get; }
        public string AccountType { get;}
        public decimal Balance { get; private set; }

        public void CalculateAndApplyInterest(RefactoredInterestCalculator refactoredInterestCalculator)
        {
            var interest = refactoredInterestCalculator.CalculateInterest(this);
            IncreaseBalance(interest);
        }

        private void IncreaseBalance(decimal amount)
        {
            // add logging and audit trail
            Balance += amount;
        }
    }
}