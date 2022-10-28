 
namespace Feca.SMS.Termii.Models
{
    public class TermiiNewSenderIDRequest
    {
        public string Api_Key { get; set; } = string.Empty;

        /// <summary>
        /// Sender_Id eg. Acme
        /// Represents the ID of the sender which can be alphanumeric or numeric. Alphanumeric sender ID length should be between 3 and 11 characters
        /// </summary>
        public string Sender_Id { get; set; } = string.Empty;

        /// <summary>
        /// Usecase is to give sample of the message you will be sent. An example is:
        /// Your OTP code is 12345678
        /// 
        /// </summary>
        public string Usecase { get; set; } = string.Empty;

        /// <summary>
        /// Company eg. Acme Corp
        /// </summary>
        public string Company { get; set; } = string.Empty;

    }

    public class TermiiNewSenderIDResponse
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

    }

}
