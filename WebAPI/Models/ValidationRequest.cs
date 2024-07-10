namespace WebAPI.Models
{
    public class ValidationRequest
    {
        public int Id { get; set; }
        public string? CreditCardNumber { get; set; }
        public bool IsValid { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
