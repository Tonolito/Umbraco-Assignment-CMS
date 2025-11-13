using Azure;
using Azure.Communication.Email;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Models.Email;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco_Assignment_CMS.Models;
namespace Umbraco_Assignment_CMS.Services;

public class EmailService
{
    private readonly IConfiguration _configuration;
    private readonly EmailClient _emailClient;
    public EmailService(IConfiguration configuration, EmailClient emailClient)
    {
        _configuration = configuration;
        _emailClient = emailClient;
    }

    public async Task<bool> SendEmailConfirmation(EmailConfirmRequest emailRequest)
    {
        try
        {


            var emailMessage = new Azure.Communication.Email.EmailMessage(
                senderAddress: _configuration["ACS:SenderAddress"],
                recipients: new EmailRecipients([new(emailRequest.Email)]),
                content: new EmailContent("Confirmed Request")
                {
                    PlainText = @"Onatrix has received your request and will contact you shortly",
                    Html = @"
		<html>
			<body>
				<h1>
					Onatrix has received your request and will contact you shortly
				</h1>
			</body>
		</html>"
                });


            var emailSendOperation = await _emailClient.SendAsync(WaitUntil.Started, emailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;

        }




    }

    
    
}
