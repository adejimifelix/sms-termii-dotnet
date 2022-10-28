
namespace Feca.SMS.Termii.Models
{
     
    public class TermiiFetchSenderIDResponse
    {
        public TermiiFetchSenderIDResponse()
        {
            this.Data = new List<TermiiFetchSenderIDResponseData>();
        }
        public int current_page { get; set; }
        public List<TermiiFetchSenderIDResponseData>? Data { get; set; }
        public string First_Page_Url { get; set; } = string.Empty;
        public int From { get; set; }
        public int Last_Page { get; set; }
        public string Last_Page_Url { get; set; } = string.Empty;
        public object? Next_Page_Url { get; set; }
        public string Path { get; set; } = string.Empty;
        public int Per_Page { get; set; }
        public object? Prev_Page_Url { get; set; }
        public int To { get; set; }
        public int Total { get; set; }
    }

    public class TermiiFetchSenderIDResponseData
    {
        public string Sender_Id { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Usecase { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Created_at { get; set; } = string.Empty;

    }



}
