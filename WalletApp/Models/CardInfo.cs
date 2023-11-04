using System.Transactions;

namespace WalletApp.Models
{
    public class CardInfo
    {
        public int UserId { get; set; }
        public int CardBalance { get; set; } 
        public int Available { get; set; }
        public string NoPaymentDue { get; set; } 

        public string DailyPoints { get; set; }
        public List<Transaction> Transactions { get; set; }
        //public string GetDailyPoints(int date, int month)
        //{
        //    return DailyPoints;
        //}

        public decimal GetAvailable()
        {
            return 1500 - this.CardBalance;
        }

        public int GetCardBalance()
        {
            Random random = new Random();
            return random.Next(1500);
        }

        public string GetNoPaymentDue(string month)
        {
            return $"You’ve paid your {month} balance";
        }

        public CardInfo(int userId, string month)
        {
            UserId = userId;
            //Available = GetAvailable();
            CardBalance = GetCardBalance();
            NoPaymentDue = GetNoPaymentDue(month);
        }
    }
}
}
