using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feca.SMS.Termii.Models
{
    public class TermiiSmsSetting
    {
        public string TermiiAPIKey { get; set; } = string.Empty;
        public string TermiiSecretKey { get; set; } = string.Empty;
        public string TermiiSenderID { get; set; } = string.Empty;

        public string TermiiCompanyName { get; set; } = string.Empty;

        public string TermiiMobileNumber { get; set; } = string.Empty;
        public string TermiiEmail { get; set; } = string.Empty;

        public string TermiiBaseUrl { get; set; } = string.Empty;

        public TermiiEndpoint TermiiEndpoint { get; set; } = new TermiiEndpoint();

    }

    public class TermiiEndpoint
    {
        public string SendSingleSms { get; set; } = string.Empty;
        public string SendBulkSms { get; set; } = string.Empty;

        public string GetAccountBalance { get; set; } = string.Empty;
        public string CheckDndStatus { get; set; } = string.Empty;
        public string FetchSenderID { get; set; } = string.Empty;
        public string RequestNewSenderID { get; set; } = string.Empty;
        public string VerifyPhoneNumberStatus { get; set; } = string.Empty;

    }
}
