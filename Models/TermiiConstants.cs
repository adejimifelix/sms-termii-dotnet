 

namespace Feca.SMS.Termii.Models
{
    public class TermiiConstants
    {
        public const string TermiiAPIKey = "TermiiAPIKey";
        public const string TermiiSecretKey = "TermiiSecretKey";
        public const string TermiiSenderID = "TermiiSenderID";
        public const string TermiiMobileNumber = "TermiiMobileNumber";
        public const string TermiiEmail = "TermiiEmail";
        public const string TermiiBaseUrl = "TermiiBaseUrl";

        public const string TermiiSmsSettingsFileName = "feca.sms.termii.json";

        public const string SuccessCode = "00";
        public const string FailedCode = "99";

        public const string SuccessMessage = "SUCCESS";
        public const string FailedMessage = "FAILED";

    }

    public enum TermiiChannel
    {
        /// <summary>
        /// Generic: SMS
        /// SMS will be sent to phone but will not be sent to DND phone number.
        /// </summary>
        Generic,

        /// <summary>
        /// DND: Do Not Disturb
        /// On this channel all your messages deliver whether there is dnd restriction or not on the phone number
        /// </summary>
        Dnd,

        /// <summary>
        /// To whatsapp channel
        /// </summary>
        Whatsapp
        
    }

    public enum TermiiMessageType
    {
        Plain,
        Unicode
    }
}
