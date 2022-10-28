using Feca.SMS.Termii.Models;

namespace Feca.SMS.Termii
{
    public interface ITermiiSmsService
    {
      
        
        
        #region Send SMS
        Task<FecaGenericResponse<TermiiSendSmsResponse>> SendSingleSMSAsync(TermiiSendSingleSmsRequest request);

        Task<FecaGenericResponse<TermiiSendSmsResponse>> SendBulkSMSAsync(TermiiSendBulkSmsRequest request);


        #endregion

        #region SenderID Methods

        Task<FecaGenericResponse<TermiiNewSenderIDResponse>> RequestNewSenderIDAsync(TermiiNewSenderIDRequest request);
     
        Task<FecaGenericResponse<TermiiFetchSenderIDResponse>> FetchSenderIDAsync(string api_key);

        #endregion

        #region Events
        Task<FecaGenericResponse<TermiiBalanceResponse>> GetAccountBalanceAsync(string api_key);

        Task<FecaGenericResponse<TermiiDndStatusCheckResponse>> CheckPhoneNumberDndStatusAsync(TermiiDndStatusCheckRequest request);

        Task<FecaGenericResponse<TermiiVerifyPhoneNumberStatusResponse>> VerifyPhoneNumberStatusAsync(TermiiVerifyPhoneNumberStatusRequest request);


        #endregion


    }
}
