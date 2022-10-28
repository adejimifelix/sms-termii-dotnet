 
namespace Feca.SMS.Termii.Models
{
    public class FecaGenericResponse<T> where T: class
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;

        public T? Data { get; set; } 

    }
}
