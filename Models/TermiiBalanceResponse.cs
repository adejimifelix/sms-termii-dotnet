 
namespace Feca.SMS.Termii.Models
{
    public class TermiiBalanceResponse
    {
        /*
          {
      "user": "Tayo Joel",
      "balance": 0,
      "currency": "NGN"
  }
         */
        public string User { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = string.Empty;



    }
}
