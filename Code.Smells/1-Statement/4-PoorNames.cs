using System.Text;

namespace Code.Smells._1_Statement
{

    public class PoorNames
    {
        private static List<int> Generate_PoorNameApproach(int n)
        {
            var x = new List<int>();
            for (int i = 2; n > 1; i++)
                for (; n % i == 0; n /= i)
                    x.Add(i);
            return x;
        }

        private static List<int> GeneratePrimeFactorsOf_DescriptiveNameApproach(int input)
        {
            var primeFactors = new List<int>();
            for (int candidateFactor = 2; input > 1; candidateFactor++)
                while (input % candidateFactor == 0)
                {
                    primeFactors.Add(candidateFactor);
                    input /= candidateFactor;
                }
            return primeFactors;
        }

        private readonly IOrderSource _orderSource;
        private void ProcessOrder_LowLevelImplementationDetailsApproach()
        {
            var orderFromFile_LowLevelImplementation = _orderSource.GetOrder();
        }

        private void ProcessOrder_AppropriateAbstractionLevelApproach()
        {
            var order = _orderSource.GetOrder();
        }

        private void OrderCreation_NonStandardNamingConventionsApproach()
        {
            var customer = CustomerFactory.Create(123);
            var Order = OrderBuilder.Make(234);
            var Orderitem = OrderItemMaker.NewItem();
        }

        private void OrderCreation_StandardNamingConventionsApproach()
        {
            var customer = CustomerFactory.Create(123);
            var Order = OrderBuilder.Create(234);
            var Orderitem = OrderItemMaker.Create();
        }

        private void TransferMoney_AmbiguousApproach()
        {
            var accountOne = new Account();
            var accountTwo = new Account();
            var accountThree = new Account();
            int amount = 5000;

            bool result = Bank.Transfer(amount, accountOne, accountTwo, accountThree);
        }

        private void TransferMoney_UnAmbiguousApproach()
        {
            var sender = new Account();
            var reciepient = new Account();
            var commissionAccount = new Account();
            var amount = 5000;

            bool result = Bank.Transfer(amount, sender, reciepient, commissionAccount);
        }

        private void ListUsers_PoorSHortNamesForLongScopeVariables()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < A.UC; i++)
            {
                sb.Append("User" + i + E.NL);
            }
            var result = sb.ToString();
        }

        private void ListUsers_LongNamesForLongScopeVariables()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Application.CurrentUserAccount; i++)
            {
                sb.Append("User" + i + Environment.NewLine);
            }
            var result = sb.ToString();
        }

        private void Variables_EncodingApproach()
        {
            string strName;
            int iCount;
            DateTime dtStart;
            DateTime dtEnd;
            User usrOne;
            User usrTwo;
            Sq1UserRepository surDataAccess;
            List<User> stUsers;
        }

        private void Variables_NonEncodingApproach()
        {
            string name;
            int count;
            DateTime StartDate;
            DateTime EndDate;
            User user1;
            User user2;
            Sq1UserRepository userRepository;
            List<User> users;
            string userName = UserNameTextBox.Text;
            UserNameLabel.Text = userName;
        }
    }

    internal class UserNameLabel
    {
        public static string Text { get; internal set; }
    }

    internal class UserNameTextBox
    {
        internal static readonly string Text;
    }

    internal class Sq1UserRepository
    {
    }

    internal class User
    {
    }

    internal class Environment
    {
        internal static readonly string NewLine;
    }

    internal class Application
    {
        internal static readonly int CurrentUserAccount;
    }

    internal class E
    {
        internal static readonly string NL;
    }

    internal class A
    {
        internal static readonly int UC;
    }

    internal class Bank
    {
        internal static bool Transfer(int amount, Account sender, Account reciepient, Account commissionAccount)
        {
            throw new NotImplementedException();
        }
    }

    internal class Account
    {
    }

    internal class OrderItemMaker
    {
        internal static object Create()
        {
            throw new NotImplementedException();
        }

        internal static object NewItem()
        {
            throw new NotImplementedException();
        }
    }

    internal class OrderBuilder
    {
        internal static object Create(int v)
        {
            throw new NotImplementedException();
        }

        internal static object Make(int v)
        {
            throw new NotImplementedException();
        }
    }

    internal class CustomerFactory
    {
        internal static object Create(int v)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IOrderSource
    {
        public string GetOrder();
    }
}
