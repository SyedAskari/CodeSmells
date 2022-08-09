namespace Code.Smells.Class
{
    public class TemporaryField
    {
        public void Execute()
        {
            var employee = new Employee_TemporaryField();
            employee.CalculateEarningsForBonus();
            employee.CalculateBonus_WillOnlyWorkCorrectly_WhenCalledAfterCalculateEarningsForBonus();


            var bonusCalculator = new BonusCalculator(new Employee());
            var totalBonus = bonusCalculator.CalculateBonus();
        }
    }

    internal class BonusCalculator
    {
        private Employee _employee;
        public BonusCalculator(Employee employee)
        {
            _employee = employee;
        }

        public decimal CalculateBonus()
        {
            return CalculateEarningsForBonus() * _employee.BonusPercentage();
        }

        private decimal CalculateEarningsForBonus()
        {
            return _employee.YearToDateEarnings() + _employee.OvertimeEarnings() * 2;
        }
    }

    public class Employee
    {
        public int YearToDateEarnings()
        {
            throw new NotImplementedException();
        }

        public int OvertimeEarnings()
        {
            throw new NotImplementedException();
        }

        public decimal BonusPercentage()
        {
            throw new NotImplementedException();
        }
    }

    internal class Employee_TemporaryField
    {
        private decimal _earningsForBonus;

        public decimal CalculateBonus_WillOnlyWorkCorrectly_WhenCalledAfterCalculateEarningsForBonus()
        {
            return _earningsForBonus * BonusPercentage();
        }

        public void CalculateEarningsForBonus()
        {
            _earningsForBonus = YearToDateEarnings() + OvertimeEarnings() * 2;
        }

        private int YearToDateEarnings()
        {
            throw new NotImplementedException();
        }

        private int OvertimeEarnings()
        {
            throw new NotImplementedException();
        }

        private decimal BonusPercentage()
        {
            throw new NotImplementedException();
        }
    }
}
