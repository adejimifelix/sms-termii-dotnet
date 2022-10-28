
namespace Feca.SMS.Termii.Models
{
    public class TermiiVerifyPhoneNumberStatusRequest
    {
        public string Api_Key { get; set; } = string.Empty;

        /// <summary>
        /// Phone_Number represents the phone number to be verified. Phone number must be in the international format (Example: 2348753243651)
        /// </summary>
        public string Phone_Number { get; set; } = string.Empty;


        public string Country_Code { get; set; } = "NG";

    }

    
    public class TermiiVerifyPhoneNumberStatusResponse
    {
        public TermiiVerifyPhoneNumberStatusResponse()
        {
            this.Result = new List<VerifyPhoneResult>();
        }
        public List<VerifyPhoneResult>? Result { get; set; }
    }

    public class VerifyPhoneResult
    {
        public RouteDetail? RouteDetail { get; set; }
        public CountryDetail? countryDetail { get; set; }
        public OperatorDetail? operatorDetail { get; set; }
        public int Status { get; set; }
    }

    public class RouteDetail
    {
        public string Number { get; set; } = string.Empty;
        public int Ported { get; set; }
    }

    public class CountryDetail
    {
        public string CountryCode { get; set; } = string.Empty;
        public string MobileCountryCode { get; set; } = string.Empty;
        public string Iso { get; set; } = string.Empty;
    }

    public class OperatorDetail
    {
        public string OperatorCode { get; set; } = string.Empty;
        public string OperatorName { get; set; } = string.Empty;
        public string MobileNumberCode { get; set; } = string.Empty;
        public string MobileRoutingCode { get; set; } = string.Empty;
        public string CarrierIdentificationCode { get; set; } = string.Empty;
        public string LineType { get; set; } = string.Empty;
    }



}
