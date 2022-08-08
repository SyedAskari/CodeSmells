using Code.Smells.Common;

namespace Code.Smells._1_Statement
{
    public class PrimitiveObession
    {
        private const int INVALID_VALUE_FROM_API = 40;
        private void Explanation()
        {
            AddHolidays_PrimitiveObsessionApproach(3, 4, 2022);

            var independenceDay = new DateTime(year: 2022, month: 3, day: 4);
            AddHolidays_NonPrimitivesApproach(independenceDay);

            AddHolidays_ConstantsApproach(Constants.Month.MARCH, Constants.Day.DAY_1, Constants.Year.YEAR_2021);

            AddHolidays_EnumAppraoch(Enums.Month.March, Enums.Day.DAY_1, Enums.Year.YEAR_2022);
            AddHolidays_EnumApproach((Enums.Month)13, (Enums.Day)INVALID_VALUE_FROM_API, (Enums.Year)0001);
            AddHolidays_SmartEnumApproach(MonthEnum.January);
        }

        private void AddHolidays_PrimitiveObsessionApproach(int month, int day, int year)
        {
            throw new NotImplementedException();
        }

        private void AddHolidays_NonPrimitivesApproach(DateTime independenceDay)
        {
            throw new NotImplementedException();
        }

        private void AddHolidays_SmartEnumApproach(MonthEnum january)
        {
            throw new NotImplementedException();
        }

        private void AddHolidays_EnumApproach(Enums.Month month, Enums.Day day, Enums.Year year)
        {
            throw new NotImplementedException();
        }

        private void AddHolidays_EnumAppraoch(Enums.Month march, Enums.Day day, Enums.Year year)
        {
            throw new NotImplementedException();
        }

        private void AddHolidays_ConstantsApproach(int month, int day, int year)
        {
            throw new NotImplementedException();
        }
    }
}
