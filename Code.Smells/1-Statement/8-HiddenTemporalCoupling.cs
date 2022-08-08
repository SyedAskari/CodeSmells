using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.SmellsStatement
{
    public class HiddenTemporalCoupling
    {

        public void MakingChickenPizza_UsingTemporalCouplingApproach_CorrectSequence()
        {
            PrepareCrust();
            AddToppings();
            Bake();
            CutIntoSlices();
        }

        public void MakingVegetablePizza_UsingTemporalCouplingApproach_InCorrectSequence()
        {
            PrepareCrust();
            AddToppings();
            CutIntoSlices();
            Bake();
        }

        public void MakingPizza_UsingTemplateDesignPatternApproach_SequenceOfTheCallsRemainsSameImplementationCanVary() 
        {
            var chickenPizza = new MakeChickenPizza();
            chickenPizza.MakeBakedGood();

            var vegetablePizza = new MakeVegetablePizza();
            vegetablePizza.MakeBakedGood();
        }

        public void MakingPizza_AlternativeToTemplateDesinPatternApproach()
        {
            Crust crust = PreparePizzaCrust();
            ToppedCrust toppedCrust = AddToppings(crust);
            BakedItem bakedItem = Bake(toppedCrust);
            SlicedItem slicedItem = CutIntoSlices(bakedItem);
        }

        private SlicedItem CutIntoSlices(BakedItem bakedItem)
        {
            throw new NotImplementedException();
        }

        private BakedItem Bake(ToppedCrust toppedCrust)
        {
            throw new NotImplementedException();
        }

        private ToppedCrust AddToppings(Crust crust)
        {
            throw new NotImplementedException();
        }

        private Crust PreparePizzaCrust()
        {
            throw new NotImplementedException();
        }

        private void CutIntoSlices()
        {
            throw new NotImplementedException();
        }

        private void Bake()
        {
            throw new NotImplementedException();
        }

        private void AddToppings()
        {
            throw new NotImplementedException();
        }

        private void PrepareCrust()
        {
            throw new NotImplementedException();
        }
    }

    internal abstract class BakedGoodBase
    {
        public void MakeBakedGood()
        {
            PrepareCrust();
            AddToppings();
            Bake();
            CutIntoSlices();
        }
        protected abstract void PrepareCrust();
        protected abstract void AddToppings();
        protected abstract void Bake();
        protected virtual void CutIntoSlices()
        {
            throw new NotImplementedException();
        }
    }

    internal class MakeChickenPizza : BakedGoodBase
    {
        protected override void AddToppings()
        {
            throw new NotImplementedException();
        }

        protected override void Bake()
        {
            throw new NotImplementedException();
        }

        protected override void PrepareCrust()
        {
            throw new NotImplementedException();
        }
    }

    internal class MakeVegetablePizza : BakedGoodBase
    {
        protected override void AddToppings()
        {
            throw new NotImplementedException();
        }

        protected override void Bake()
        {
            throw new NotImplementedException();
        }

        protected override void PrepareCrust()
        {
            throw new NotImplementedException();
        }
    }

    internal class SlicedItem
    {
    }

    internal class BakedItem
    {
    }

    internal class ToppedCrust
    {
    }

    internal class Crust
    {
    }

}
