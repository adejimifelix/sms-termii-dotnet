using Feca.SMS.Termii.Models;
using System.Net.Mime;

namespace Feca.SMS.Termii
{
    public class TermiiSmsService : ITermiiSmsService
    {
        private readonly ILogger<TermiiSmsService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TermiiSmsSetting _termiiSmsSetting = new TermiiSmsSetting();

        private readonly JsonSerializerOptions _jsonSerializationOptions = new JsonSerializerOptions() { AllowTrailingCommas = true, PropertyNameCaseInsensitive = true, MaxDepth = 125, PropertyNamingPolicy = null };
        public TermiiSmsService(ILogger<TermiiSmsService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;   
            _httpClientFactory = httpClientFactory; 
            try {
                var jsonString = File.ReadAllText(TermiiConstants.TermiiSmsSettingsFileName);
                _termiiSmsSetting = JsonSerializer.Deserialize<TermiiSmsSetting>(jsonString) ?? new TermiiSmsSetting();
            }
            catch(Exception ex)
            {
                _logger.LogError(exception: ex, message: "Termii SMS Settings failed", args: new object() { });
            }
        }

        #region Send SMS 
        public async Task<FecaGenericResponse<TermiiSendSmsResponse>> SendSingleSMSAsync(TermiiSendSingleSmsRequest request)
        {
            var result = new FecaGenericResponse<TermiiSendSmsResponse>();
            result.ResponseCode = TermiiConstants.FailedCode;
            result.ResponseMessage = TermiiConstants.FailedMessage;
             
            try
            {
                if (string.IsNullOrWhiteSpace(request.Type)) request.Type = TermiiMessageType.Plain.ToString().ToLower();
                if (string.IsNullOrWhiteSpace(request.Api_key)) request.Api_key = _termiiSmsSetting.TermiiAPIKey;
                if (string.IsNullOrWhiteSpace(request.From)) request.From = _termiiSmsSetting.TermiiSenderID;
                if (string.IsNullOrWhiteSpace(request.Channel)) request.Channel = TermiiChannel.Generic.ToString().ToLower();

                

                string url = $"{_termiiSmsSetting.TermiiBaseUrl}{_termiiSmsSetting.TermiiEndpoint.SendSingleSms}";
                var client = _httpClientFactory.CreateClient();

                var payload = JsonSerializer.Serialize<TermiiSendSingleSmsRequest>(value: request, options: new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase} );

                var stringContent = new StringContent(payload, encoding: Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
                var response = await client.PostAsync(requestUri: url, content: stringContent);

             //   response.EnsureSuccessStatusCode();
                if(response != null && response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                { 
                        var responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation(responseContent);

                        result.ResponseCode = TermiiConstants.SuccessCode;
                        result.ResponseMessage = TermiiConstants.SuccessMessage;
                       
                        result.Data = JsonSerializer.Deserialize<TermiiSendSmsResponse>(responseContent, _jsonSerializationOptions);
                                        
                }
                else if(response != null && response.StatusCode != HttpStatusCode.OK)
                {
                    result.ResponseMessage = response.StatusCode.ToString();
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(exception: ex, message: "Sending Termii Single SMS failed", args: new object(){ });
                _logger.LogInformation(ex.StackTrace);
            }
            return result;
        }

        public async Task<FecaGenericResponse<TermiiSendSmsResponse>> SendBulkSMSAsync(TermiiSendBulkSmsRequest request)
        {
            var result = new FecaGenericResponse<TermiiSendSmsResponse>();
            result.ResponseCode = TermiiConstants.FailedCode;
            result.ResponseMessage = TermiiConstants.FailedMessage;

            try
            {
                if (string.IsNullOrWhiteSpace(request.Type)) request.Type = TermiiMessageType.Plain.ToString().ToLower();
                if (string.IsNullOrWhiteSpace(request.Api_key)) request.Api_key = _termiiSmsSetting.TermiiAPIKey;
                if (string.IsNullOrWhiteSpace(request.From)) request.From = _termiiSmsSetting.TermiiSenderID;
                if (string.IsNullOrWhiteSpace(request.Channel)) request.Channel = TermiiChannel.Generic.ToString().ToLower();



                string url = $"{_termiiSmsSetting.TermiiBaseUrl}{_termiiSmsSetting.TermiiEndpoint.SendBulkSms}";
                var client = _httpClientFactory.CreateClient();

                var payload = JsonSerializer.Serialize<TermiiSendBulkSmsRequest>(value: request, options: new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });


                var stringContent = new StringContent(payload, encoding: Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
                var response = await client.PostAsync(requestUri: url, content: stringContent);

              //  response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                { 
                        var responseContent = await response.Content.ReadAsStringAsync();

                        result.ResponseCode = TermiiConstants.SuccessCode;
                        result.ResponseMessage = TermiiConstants.SuccessMessage;
                        result.Data = JsonSerializer.Deserialize<TermiiSendSmsResponse>(responseContent, _jsonSerializationOptions);
                                      
                }
                else if(response != null && response.StatusCode != HttpStatusCode.OK)
                {
                    result.ResponseMessage = response.StatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: "Sending Termii Bulk SMS failed", args: new object() { });
                _logger.LogInformation(ex.StackTrace);
            }
            return result;
        }


        #endregion



        #region SenderID Endpoints


        public async Task<FecaGenericResponse<TermiiFetchSenderIDResponse>> FetchSenderIDAsync(string api_key)
        {
            var result = new FecaGenericResponse<TermiiFetchSenderIDResponse>();
            result.ResponseCode = TermiiConstants.FailedCode;
            result.ResponseMessage = TermiiConstants.FailedMessage;

            try
            {
                if (string.IsNullOrWhiteSpace(api_key)) api_key = _termiiSmsSetting.TermiiAPIKey;


                string url = $"{_termiiSmsSetting.TermiiBaseUrl}" + string.Format(_termiiSmsSetting.TermiiEndpoint.FetchSenderID, api_key);
                var client = _httpClientFactory.CreateClient();

                var response = await client.GetAsync(requestUri: url);

                //response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                       var responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation(responseContent);
                        result.ResponseCode = TermiiConstants.SuccessCode;
                        result.ResponseMessage = TermiiConstants.SuccessMessage;
                       // result.ResponseMessage = responseContent;
                        result.Data = JsonSerializer.Deserialize<TermiiFetchSenderIDResponse>(responseContent, _jsonSerializationOptions);
               
                }
                else if (response != null && response.StatusCode != HttpStatusCode.OK)
                {
                    result.ResponseMessage = response.StatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: "Fetching Termii SenderID failed", args: new object() { });
                _logger.LogInformation(ex.StackTrace);
            }
            return result;
        }

        public async Task<FecaGenericResponse<TermiiNewSenderIDResponse>> RequestNewSenderIDAsync(TermiiNewSenderIDRequest request)
        {
            var result = new FecaGenericResponse<TermiiNewSenderIDResponse>();
            result.ResponseCode = TermiiConstants.FailedCode;
            result.ResponseMessage = TermiiConstants.FailedMessage;

            Random rnd = new Random(1000);
            try
            {
                if (string.IsNullOrWhiteSpace(request.Sender_Id)) request.Sender_Id = _termiiSmsSetting.TermiiSenderID;
                if (string.IsNullOrWhiteSpace(request.Api_Key)) request.Api_Key = _termiiSmsSetting.TermiiAPIKey;
                if (string.IsNullOrWhiteSpace(request.Company)) request.Company = _termiiSmsSetting.TermiiCompanyName;

                if (string.IsNullOrWhiteSpace(request.Usecase)) request.Usecase = $"Your OTP is {rnd.NextInt64(100000,999999)}";

                string url = $"{_termiiSmsSetting.TermiiBaseUrl}{_termiiSmsSetting.TermiiEndpoint.RequestNewSenderID}";
                var client = _httpClientFactory.CreateClient();
              
                var stringContent = new StringContent(JsonSerializer.Serialize(request), encoding: Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
                var response = await client.PostAsync(requestUri: url, content: stringContent);

               // response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                { 
                        var responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation(responseContent);
                        result.ResponseCode = TermiiConstants.SuccessCode;
                        result.ResponseMessage = TermiiConstants.SuccessMessage;
                        result.ResponseMessage = responseContent;
                        result.Data = JsonSerializer.Deserialize<TermiiNewSenderIDResponse>(responseContent, _jsonSerializationOptions);
                    
                }
                else if (response != null && response.StatusCode != HttpStatusCode.OK)
                {
                    result.ResponseMessage = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: "Requesting new Termii SenderID failed", args: new object() { });
                _logger.LogInformation(ex.StackTrace);
            }
            return result;
        }


        #endregion


        #region Events


        public async Task<FecaGenericResponse<TermiiBalanceResponse>> GetAccountBalanceAsync(string api_key)
        {
            var result = new FecaGenericResponse<TermiiBalanceResponse>();
            result.ResponseCode = TermiiConstants.FailedCode;
            result.ResponseMessage = TermiiConstants.FailedMessage;
            try
            {
                if (string.IsNullOrWhiteSpace(api_key)) api_key = _termiiSmsSetting.TermiiAPIKey;


                string url = $"{_termiiSmsSetting.TermiiBaseUrl}" + string.Format(_termiiSmsSetting.TermiiEndpoint.GetAccountBalance, api_key);
                var client = _httpClientFactory.CreateClient();

                var response = await client.GetAsync(requestUri: url);

               // response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                { 
                        var responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation(responseContent);

                        result.ResponseCode = TermiiConstants.SuccessCode;
                        result.ResponseMessage = TermiiConstants.SuccessMessage;
                        //   result.ResponseMessage = responseContent;
                        result.Data = JsonSerializer.Deserialize<TermiiBalanceResponse>(responseContent, _jsonSerializationOptions);
                                        
                }
                 
                    else if (response != null && response.StatusCode != HttpStatusCode.OK)
                    {
                        result.ResponseMessage = response.StatusCode.ToString();
                    }
                

            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: "Fetching Termii account balance failed", args: new object() { });
                _logger.LogInformation(ex.StackTrace);
            }
            return result;
        }

        public async Task<FecaGenericResponse<TermiiDndStatusCheckResponse>> CheckPhoneNumberDndStatusAsync(TermiiDndStatusCheckRequest request)
        {
            var result = new FecaGenericResponse<TermiiDndStatusCheckResponse>();
            result.ResponseCode = TermiiConstants.FailedCode;
            result.ResponseMessage = TermiiConstants.FailedMessage;
            try
            {
                if (string.IsNullOrWhiteSpace(request.Api_Key)) request.Api_Key = _termiiSmsSetting.TermiiAPIKey;


                string url = $"{_termiiSmsSetting.TermiiBaseUrl}" + string.Format(_termiiSmsSetting.TermiiEndpoint.CheckDndStatus, request.Api_Key, request.Phone_Number );
                var client = _httpClientFactory.CreateClient();

                var response = await client.GetAsync(requestUri: url);

               // response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    
                        var responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation(responseContent);

                        result.ResponseCode = TermiiConstants.SuccessCode;
                        result.ResponseMessage = TermiiConstants.SuccessMessage;
                         
                        result.Data = JsonSerializer.Deserialize<TermiiDndStatusCheckResponse>(responseContent, _jsonSerializationOptions);

                    
                }
                else if (response != null && response.StatusCode != HttpStatusCode.OK)
                {
                    result.ResponseMessage = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: "Fetching Termii account balance failed", args: new object() { });
                _logger.LogInformation(ex.StackTrace);
            }
            return result;
        }

        public async Task<FecaGenericResponse<TermiiVerifyPhoneNumberStatusResponse>> VerifyPhoneNumberStatusAsync(TermiiVerifyPhoneNumberStatusRequest request)
        {
            var result = new FecaGenericResponse<TermiiVerifyPhoneNumberStatusResponse>();
            result.ResponseCode = TermiiConstants.FailedCode;
            result.ResponseMessage = TermiiConstants.FailedMessage;
            try
            {
                if (string.IsNullOrWhiteSpace(request.Api_Key)) request.Api_Key = _termiiSmsSetting.TermiiAPIKey;
                if (string.IsNullOrWhiteSpace(request.Country_Code)) request.Country_Code = "NG";


                string url = $"{_termiiSmsSetting.TermiiBaseUrl}" + string.Format(_termiiSmsSetting.TermiiEndpoint.VerifyPhoneNumberStatus, request.Phone_Number, request.Api_Key, request.Country_Code);
                var client = _httpClientFactory.CreateClient();

                var response = await client.GetAsync(requestUri: url);

              //  response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                { 
                        var responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation(responseContent);

                        result.ResponseCode = TermiiConstants.SuccessCode;
                        result.ResponseMessage = TermiiConstants.SuccessMessage;
                        result.Data = JsonSerializer.Deserialize<TermiiVerifyPhoneNumberStatusResponse>(responseContent, _jsonSerializationOptions);
                     
                }
                else if (response != null && response.StatusCode != HttpStatusCode.OK)
                {
                    result.ResponseMessage = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: "Verifying phone number status failed", args: new object() { });
                _logger.LogInformation(ex.StackTrace);
            }
            return result;
        }


        #endregion



    }
}
