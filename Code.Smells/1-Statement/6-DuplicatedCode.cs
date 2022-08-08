using Ardalis.GuardClauses;

namespace Code.Smells.Statement
{
    public class DuplicatedCode
    {
        private void MethodInClassA_DuplicatedGuardClauseLogicApproach_ValidationLogicMustBeChangedInBothMethods(Customer customer, Order order, Logger logger)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Customer cannot be null");
            }

            if (order == null)
            {
                throw new ArgumentNullException("Order cannot be null");
            }

            if (logger == null)
            {
                throw new ArgumentNullException("Logger cannot be null");
            }
        }
        private void MethodInClassB_DuplicatedGuardClauseLogicApproach_ValidationLogicMustBeChangedInBothMethods(Customer customer, Order order, Logger logger)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Customer cannot be null");
            }

            if (order == null)
            {
                throw new ArgumentNullException("Order cannot be null");
            }

            if (logger == null)
            {
                throw new ArgumentNullException("Logger cannot be null");
            }
        }

        private void MethodInClassA_CommonValidationCheckInGuardClauseApproach_ValidationLogicOnlyChangedInGuardClass(Customer customer, Order order, Logger logger)
        {
            Guard.Against.Null(customer, nameof(customer));
            Guard.Against.Null(order, nameof(order));
            Guard.Against.Null(logger, nameof(logger));
        }
        private void MethodInClassB_CommonValidationCheckInGuardClauseApproach_ValidationLogicOnlyChangedInGuardClass(Customer customer, Order order, Logger logger)
        {
            Guard.Against.Null(customer, nameof(customer));
            Guard.Against.Null(order, nameof(order));
            Guard.Against.Null(logger, nameof(logger));
        }

    }

    internal class Logger
    {
    }

    internal class Order
    {
    }

    internal class Customer
    {
    }
}
