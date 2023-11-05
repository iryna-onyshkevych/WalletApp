using System.Globalization;
using WalletApp.Constants;

namespace WalletApp.Models
{
    public class CardInfo
    {
        public int UserId { get; set; }
        public decimal CardBalance { get; set; }
        public decimal Available { get; set; }
        public string NoPaymentDue { get; set; }
        public string DailyPoints { get; set; }
        public List<Transaction> Transactions { get; set; }

        private static Dictionary<decimal, decimal> list = new Dictionary<decimal, decimal>();

        public CardInfo(int userId, int day, int month)
        {
            UserId = userId;
            Available = GetAvailable();
            CardBalance = GetCardBalance();
            NoPaymentDue = GetNoPaymentDue(month);
            DailyPoints = ConvertDailyPoints(GetDailyPoints(ConvertToSeasonDay(day, month)));
        }

        public decimal GetAvailable()
        {
            return Constant.MaxCardLimit - this.CardBalance;
        }

        private decimal GetDailyPoints(decimal date)
        {
            if (date == 1)
                return Constant.FirstDayOfSeasonPoints;
            if (date == 2)
                return Constant.SecondDayOfSeasonPoints;

            if (list.ContainsKey(date))
                return list[date];

            decimal result = Constant.OrdinaryDayOfSeasonPoints * GetDailyPoints(date - 1) + GetDailyPoints(date - 2);
            list[date] = result;
            return result;
        }

        public static string ConvertDailyPoints(decimal number)
        {
            return number >= 1000 ? ((int)Math.Round(number / Constant.DailyPointCondition)).ToString() + "K" : number.ToString();
        }

        public static decimal ConvertToSeasonDay(int date, int month)
        {
            var season = month % 3;
            if (season == 1)
                date = date + Constant.DaysInAMonth;
            else if (season == 2)
                date = date + 2 * Constant.DaysInAMonth;
            return date;
        }

        public decimal GetCardBalance()
        {
            return new Random().Next(Constant.MaxCardLimit);
        }

        public string GetNoPaymentDue(int month)
        {
            var cultureInfo = new CultureInfo("en-US", false);
            return $"You've paid your {cultureInfo.DateTimeFormat.GetMonthName(month)} balance";
        }
    }
}

