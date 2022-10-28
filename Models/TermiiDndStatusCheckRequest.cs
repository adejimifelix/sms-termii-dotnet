 
namespace Feca.SMS.Termii.Models
{
    public class TermiiDndStatusCheckRequest
    {
        public string Api_Key { get; set; } = string.Empty;

        public string Phone_Number { get; set; } = string.Empty;

    }

    public class TermiiDndStatusCheckResponse
    {
        public string Number { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Network { get; set; } = string.Empty;

        public string Network_Code { get; set; } = string.Empty;


    }



}
