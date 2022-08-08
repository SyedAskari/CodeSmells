using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Smells.Class
{
    public class ParallelInheritanceHierarchies
    {

    }

    internal class ShippingService_ParallelHirerachy
    {

    }

    internal class PremiumShippingService_ParallelHirerachy : ShippingService_ParallelHirerachy
    {
        public PremiumShippingStrategy_ParallelHirerachy? premiumShippingStrategy_ParallelHirerachy;
    }

    internal class StandardShippingService_ParallelHirerachy : ShippingService_ParallelHirerachy
    {
        public StandardShippingStrategy_ParallelHirerachy? standardShippingStrategy_ParallelHirerachy;
    }

    internal abstract class ShippingCostStrategy_ParallelHirerachy
    {
        public abstract int GetCost();
    }

    internal class PremiumShippingStrategy_ParallelHirerachy : ShippingCostStrategy_ParallelHirerachy
    {
        public override int GetCost()
        {
            throw new NotImplementedException();
        }
    }

    internal class StandardShippingStrategy_ParallelHirerachy : ShippingCostStrategy_ParallelHirerachy
    {
        public override int GetCost()
        {
            throw new NotImplementedException();
        }
    }

    internal class ShippingService
    {
        public ShippingCostStrategy shippingCostStrategy;
    }

    internal class PremiumShippingService : ShippingService
    {

    }

    internal class StandardShippingService : ShippingService
    {

    }

    internal class ShippingCostStrategy 
    { 
        public int GetPremiumCost()
        {
            throw new NotImplementedException();
        }

        public int GetStandardCost()
        {
            throw new NotImplementedException();
        }
    }
}
