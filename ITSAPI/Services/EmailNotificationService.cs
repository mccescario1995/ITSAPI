using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;

namespace ITSAPI.Services;

public class EmailNotificationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<EmailNotificationService> _logger;

    public EmailNotificationService(HttpClient httpClient, ILogger<EmailNotificationService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task SendNewCreateIssueEmailAsync(string toEmail, string issueNumber)
    {
        try
        {
            var trackUrl = "https://apps.fastlogistics.com.ph/its/guest/check-feedback";

            var emailBody = $@"
                <html>
                <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                    <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                        <h2 style='color: #2c3e50;'>New Issue Created</h2>
                        <p>Dear User,</p>

                        <p>Your issue has been successfully submitted to the IT Support System.</p>
                        <p>A new ticket has been generated for your request. Please keep the Issue number below for your records:</p>

                        <p style='margin: 20px 0; padding: 15px; background-color: #f4f6f6; border-left: 5px solid #2f6b4a; font-size: 18px; font-weight: bold;'>
                            Issue Number: <span style='color: #2f6b4a;'>{issueNumber}</span>
                        </p>

                        <p>Our team will review your request shortly. You can track the progress of your issue anytime using the button below:</p>

                        <p style='margin: 20px 0;'>
                            <a href='{trackUrl}' 
                            style='display: inline-block; padding: 12px 30px; background-color: #2f6b4a; color: white; 
                                    text-decoration: none; border-radius: 5px; font-weight: bold;'>
                                View Issue Status
                            </a>
                        </p>

                        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;' />

                        <p style='color: #7f8c8d; font-size: 12px;'>
                            Best regards,<br>
                            ITS Support Team<br>
                            <a href='https://support.fastlogistics.com.ph/' style='color: #7f8c8d;'>https://support.fastlogistics.com.ph/</a>
                        </p>
                    </div>
                </body>
                </html>";

            var requestBody = new
            {
                senderDisplayName = "its.noreply@fastlogistic.ph",
                recipient = toEmail,
                bccrecipient = "mcccescario@fast.com.ph",
                mailSubject = $"Issue Submitted - Issue #{issueNumber}",
                mailBody = emailBody,
                createdBy = "ITS Admin"
            };

            var authHeader = "65d9ec1b-316f-4294-a294-d8d54f-utility";
            var apiUrl = "https://apps.fastlogistics.com.ph/utilityapi/api/Emailer/send-email";

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Headers =
                {
                    { "Authorization", authHeader }
                },
                Content = JsonContent.Create(requestBody)
            };

            using var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Issue email notification sent successfully to {Email}", toEmail);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to send ITS email notification to {Email}. Status: {StatusCode}. Response: {Response}",
                    toEmail, response.StatusCode, errorContent);
                throw new Exception($"Failed to send email. Status: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send ITS email notification to {Email}", toEmail);
            throw;
        }
    }
}
