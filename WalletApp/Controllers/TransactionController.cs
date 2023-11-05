using Microsoft.AspNetCore.Mvc;
using WalletApp.Models;
using WalletApp.Services;

namespace WalletApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        [HttpGet("{userId}")]
        public IActionResult GetData(int userId)
        {
            var cardInfo = new CardInfo(userId, DateTime.Today.Day, DateTime.Today.Month);

            using (var db = new ApplicationContext())
            {
                var data = db.Transactions
                    .Where(t => t.UserId == userId)
                    .Take(10)
                    .Select(t => new Transaction
                    {
                        Id = t.Id,
                        UserId = t.UserId,
                        Sum = t.Type.Equals("Credit") ? t.Sum : "+" + t.Sum,
                        Description = t.Pending ? "Pending - " + t.Description : t.Description,
                        Date = t.AuthorizedUser != null ? t.AuthorizedUser + " - " + StringService.DisplayDateOrDay(t.Date) : StringService.DisplayDateOrDay(t.Date),
                        Name = t.Name,
                        Icon = t.Icon
                    })
                    .ToList();

                cardInfo.Transactions = data;
            }

            return Json(cardInfo);
        }

        [HttpGet("GetTransactionDetails/{transactionId}")]
        public IActionResult GetTransactionDetails(int transactionId)
        {
            using (var db = new ApplicationContext())
            {
                Transaction transaction = db.Transactions.SingleOrDefault(t => t.Id == transactionId);

                if (transaction == null)
                {
                    return NotFound(); 
                }
                return Json(transaction);
            }
        }
    }
}
