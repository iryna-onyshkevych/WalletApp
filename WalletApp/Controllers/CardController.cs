using Microsoft.AspNetCore.Mvc;
using WalletApp.Models;

namespace WalletApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        [HttpGet("{userId}")]
        public IActionResult GetData(int userId)
        {
            CardInfo cardInfo = new CardInfo(userId, DateTime.Today.Date.ToString());
            List<Transaction> data;

            using (ApplicationContext db = new ApplicationContext())
            {

                data = db.Transactions.Where(t => t.UserId.Equals(userId)).ToList();
            }

            foreach (Transaction t in data)
            {
                Transaction transaction = new Transaction()
                {
                    Id = t.Id,
                    UserId = t.UserId,

                };

                if (t.Type.Equals("Credit"))
                    transaction.Sum = t.Sum;
                else
                    transaction.Sum = "+" + t.Sum;

                if (t.Pending)
                    transaction.Description = "Pending - " + t.Description;
                else
                    transaction.Description = t.Description;

            }

            cardInfo.Transactions = data;
            return Json(cardInfo);
        }
    }
}
