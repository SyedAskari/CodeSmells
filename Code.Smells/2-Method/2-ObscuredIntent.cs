using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Smells.Method
{
    public class ObscuredIntent
    {
        private readonly int tenthsWorked;
        private readonly int tenthsRate;

        private int m_otCalc_ObscuredIntentApproach(int iThsWkd, int iThsRte)
        {
            return iThsWkd * iThsRte + (int)Math.Round(0.5 * iThsRte * Math.Max(0, iThsWkd - 400));
        }

        private int CalculateOverTimePay_IntentionRevealingApproach()
        {
            int overTimeTenths = Math.Max(0, tenthsWorked - 400);
            int overTimePay = CalculateOverTimeBonus(overTimeTenths);
            return CalculateStraightPay() + overTimePay;
        }

        private int CalculateOverTimeBonus(int overTimeTenths)
        {
            double bonus = 0.5 * tenthsRate * overTimeTenths;
            return (int)Math.Round(bonus);
        }

        private int CalculateStraightPay()
        {
            return tenthsWorked * tenthsRate;
        }

    }
}
