# sms-termii-dotnet
Cross-platform .NET C# Library for sending SMS via mobile, web apps, or desktop apps through Termii SMS provider

This is an open-source library that I contributed for end-users using .NET 6.0 or later to integrate with Termii (see https://developers.termii.com)

Termii provides SMS services that can reach even DND mobile numbers and the price is very friendly.
See: https://www.termii.com/pricing

To sign up on their platform, go to https://accounts.termii.com/#/register

To use this library, the following information has to be entered into the json file named feca.sms.termii.json

```
 1. "TermiiAPIKey": "<See your Termii dashboard>"
 2. "TermiiSecretKey": "<See your Termii dashboard>"
 3. "TermiiSenderID": "Your SenderID"
 4. "TermiiCompanyname": "Your CompanyName"
 
 ```
 
 # How to use 

 In startup class, add the service to DI container like so:

 ```
    services.AddTransient<ITermiiSmsService, TermiiSmsService>();

 ```

 Then inject the service through controller constructor.

 To invoke the Send-Single-SMS method, do something like this:

 ```
 var sendSmsResponse = await termiiService.SendSingleSMSAsync(request: new TermiiSendSingleSmsRequest() { To = "2348099221401", Sms = "Hello Felix Adejimi!" });


 ```



