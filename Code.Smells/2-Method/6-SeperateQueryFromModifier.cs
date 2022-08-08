using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Smells.Method
{
    public class SeperateQueryFromModifier
    {


        private void ProcessAccount(IEnumerable<Account> accounts)
        {
            foreach (var account in accounts)
            {
                var overdueInvoices = account.ProcessOverdueInvoices_QueryModifierInTheSameMethodApproach_ModifyStateHasSideEffectsAndReturns(DateTime.Now);
                UpdateReport(overdueInvoices);
            }

            foreach (var account in accounts)
            {
                var processDate = DateTime.Now;
                account.ProcessOverdueInvoices_SeperateQueryModifierApproach(processDate);
                var overdueInvoices = account.ListPastDueInvoices_QueryMethod(processDate);

                UpdateReport(overdueInvoices);
            }

        }

        private void UpdateReport(IEnumerable<Invoice> overdueInvoices)
        {
            throw new NotImplementedException();
        }
    }

    internal class Account
    {
        private readonly List<Invoice> Invoices;
        private const string Status = "completed";

        public IEnumerable<Invoice> ProcessOverdueInvoices_QueryModifierInTheSameMethodApproach_ModifyStateHasSideEffectsAndReturns(DateTime processDate)
        {
            foreach (var invoice in Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate)))
            {
                if (Status != AccountStatus.Overdue)
                {
                    UpdateStatus(AccountStatus.Overdue);
                }
                SendPastDueNotice(invoice);
            }
            return Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate));
        }

        private void SendPastDueNotice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        private void UpdateStatus(string overdue)
        {
            throw new NotImplementedException();
        }


        public void ProcessOverdueInvoices_SeperateQueryModifierApproach(DateTime processDate)
        {
            foreach (var invoice in ListPastDueInvoices_QueryMethod(processDate))
            {
                if (Status != AccountStatus.Overdue)
                {
                    UpdateStatus(AccountStatus.Overdue);
                }
                SendPastDueNotice(invoice);
            }
        }

        public IEnumerable<Invoice> ListPastDueInvoices_QueryMethod(DateTime processDate)
        {
            return Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate));
        }
    }

    internal class Invoice
    {
        public bool Paid { get; set; }
        public DateTime PaymentDueDate { get; set; }

    }

    internal static class AccountStatus
    {
        public const string Overdue = "Overdue";
    }
}
