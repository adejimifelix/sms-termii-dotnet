
namespace Feca.SMS.Termii.Models
{
    public class TermiiSendSmsRequest3
    {
        public List<string> DestinationPhoneNumbers { get; set; } = new List<string>();
        public string Message { get; set; } = string.Empty;
        public string Channel { get; set; } = string.Empty;

    }

    public abstract class TermiiSendSmsRequest
    {
        /// <summary>
        /// From is a SenderID.
        /// Represents a sender ID for sms which can be Alphanumeric or Device name for Whatsapp. Alphanumeric sender ID length should be between 3 and 11 characters (Example:CompanyName)
        /// </summary>
        public string From { get; set; } = string.Empty;

        /// <summary>
        /// SMS is the text messwage being sent
        /// </summary>
        public string Sms { get; set; } = string.Empty;

        /// <summary>
        /// Type indicates the kind of message being sent. Value is plain.
        /// </summary>
        public string Type { get; set; } = TermiiMessageType.Plain.ToString().ToLower();

        /// <summary>
        /// Channel is the route through which the message is sent. It can be dnd, whatsapp, or generic
        /// </summary>
        public string Channel { get; set; } = string.Empty; // = TermiiChannel.Generic.ToString().ToLower();

        /// <summary>
        /// API_Key is your Termii API key. You can find it on your Termii dashboard.
        /// </summary>
        public string Api_key { get; set; } = string.Empty;
        
        /// <summary>
        /// Media is only applicable to High Volume Whatapp channel
        /// </summary>
       // public Media Media { get; set; } = new Media();
    
    }

    public class Media
    {
        /// <summary>
        /// Url to the the file resource. Media types accepted are Document (pdf), Images (jpeg, jpg and png), Audio (mp3, ogg and amr) and Video (mp4)
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// caption refers to media title.
        /// </summary>
        public string Caption { get; set; } = string.Empty;
    }


    public class TermiiSendSingleSmsRequest : TermiiSendSmsRequest
    {
        /// <summary>        
        /// To property represents the destination phone number. Phone number must be in the international format (Example: 23490126727). You can also send to multiple numbers. To do so put numbers in an array (Example: ["23490555546", "23423490126999"]) Please note: the array takes only 100 phone numbers at a time
        /// </summary>
        public string To { get; set; } = string.Empty;

    }


    public class TermiiSendBulkSmsRequest : TermiiSendSmsRequest
    {
        public TermiiSendBulkSmsRequest()
        {
            this.To = new List<string>();
        }
        /// <summary>
        /// To property represents the array of phone numbers you are sending to (Example: ["23490555546", "23423490126999","23490555546"]). Phone numbers must be in international format (Example: 23490126727). Please note: the array can take up to 10,000 phone numbers
        /// </summary>
        public List<string> To { get; set; } = new List<string>();
    
    }


    public class TermiiSendSmsResponse
    {
        public string Code { get; set; } = string.Empty;
        public string Message_Id { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string User { get; set; } = string.Empty;

    }

}
