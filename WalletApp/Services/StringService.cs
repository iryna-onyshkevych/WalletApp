namespace WalletApp.Services
{
    public static class StringService
    {
        public static string DisplayDateOrDay(string inputDate)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(inputDate, out parsedDate))
            {
                var timeDifference = DateTime.Now - parsedDate;
                if (timeDifference.TotalDays <= Constants.Constant.DaysInAWeek)
                {
                    return parsedDate.ToString("dddd");
                }
            }
            return parsedDate.ToString("yyyy-MM-dd");
        }
    }
}
