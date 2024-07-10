using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public CreditCardController(CreditCardContext context)
        {
            _context = context;
        }

        [HttpPost("Validate")]
        public async Task<IActionResult> ValidateCard([FromBody] ValidationRequest request)
        {
            var cardNumber = request.CreditCardNumber.Replace(" ", "");

            // Luhn Algorithm
            bool isValid = IsValidCardNumber(cardNumber);

            var cardType = GetCardType(cardNumber);

            var validationRequest = new ValidationRequest
            {
                CreditCardNumber = request.CreditCardNumber,
                IsValid = isValid,
                RequestDate = DateTime.Now
            };
            _context.ValidationRequests.Add(validationRequest);
            await _context.SaveChangesAsync();

            return Ok(new { message = isValid ? "Valid Card Number" : "Invalid Card Number" });
        }

        private bool IsValidCardNumber(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }

        private string GetCardType(string cardNumber)
        {
            if (cardNumber.StartsWith("4")) return "Visa";
            if (cardNumber.StartsWith("22") || (cardNumber.StartsWith("51") || cardNumber.StartsWith("55"))) return "Mastercard";
            if (cardNumber.StartsWith("34") || cardNumber.StartsWith("37")) return "AmEx";
            if (cardNumber.StartsWith("6011")) return "Discover";
            return "Unknown";
        }
    }

}
