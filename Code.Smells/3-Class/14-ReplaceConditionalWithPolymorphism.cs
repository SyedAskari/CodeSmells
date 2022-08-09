namespace Code.Smells.Class
{
    public enum AccountType
    {
        Checking,
        Saving,
        Public,
        Private
    }
    
    public class ReplaceConditionalWithPolymorphism {

        public void Main()
        {
            var interest = 10m;
            var checkingAccountUsingIfApproach = BankAccount_Using_IfApproach.Create(AccountType.Checking);
            checkingAccountUsingIfApproach.CalculateInterest(interest);

            var checkingAccountUsingPolymorphismApproach = BankAccount.Create(AccountType.Checking);
            checkingAccountUsingPolymorphismApproach.CalculateInterest(interest);

        }
    }

    public abstract class BankAccount_Using_IfApproach
    {
        public abstract AccountType Type { get; }

        public static BankAccount_Using_IfApproach Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Checking:
                    return new Checking_Using_IfApproach();
                case AccountType.Saving:
                    return new Saving_Using_IfApproach();
                case AccountType.Public:
                    return new Public_Using_IfApproach();
                case AccountType.Private:
                    return new Private_Using_IfApproach();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public decimal CalculateInterest(decimal amount)
        {
            if (this.Type == AccountType.Checking)
            {
                return amount;
            }

            if (this.Type == AccountType.Public)
            {
                return amount * 2.01m;
            }

            if (this.Type == AccountType.Private)
            {
                return amount * 3.01m;
            }

            return amount * 1.01m;
        }
    }

    public class Private_Using_IfApproach : BankAccount_Using_IfApproach
    {
        public override AccountType Type { get; }
    }

    public class Public_Using_IfApproach : BankAccount_Using_IfApproach
    {
        public override AccountType Type { get; }
    }

    public class Saving_Using_IfApproach : BankAccount_Using_IfApproach
    {
        public override AccountType Type => AccountType.Saving;
    }

    public class Checking_Using_IfApproach : BankAccount_Using_IfApproach
    {
        public override AccountType Type => AccountType.Checking;
    }
    
    public abstract class BankAccount
    {
        public abstract AccountType Type { get; }

        public static BankAccount Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Checking:
                    return new Checking();
                case AccountType.Saving:
                    return new Saving();
                case AccountType.Public:
                    return new Public();
                case AccountType.Private:
                    return new Private();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public abstract decimal CalculateInterest(decimal amount);
    }

    public class Public : BankAccount
    {
        public override AccountType Type => AccountType.Public;
        public override decimal CalculateInterest(decimal amount)
        {
            return amount * 2.01m;
        }
    }

    public class Private : BankAccount
    {
        public override AccountType Type => AccountType.Private;
        
        public override decimal CalculateInterest(decimal amount)
        {
            return amount * 3.01m;
        }
    }

    public class Saving : BankAccount
    {
        public override AccountType Type => AccountType.Saving;
        
        public override decimal CalculateInterest(decimal amount)
        {
            return amount * 1.01m;
        }
    }

    public class Checking : BankAccount
    {
        public override AccountType Type => AccountType.Checking;
        
        public override decimal CalculateInterest(decimal amount)
        {
            return amount;
        }
    }
}