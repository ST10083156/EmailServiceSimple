using System;
using System.Net;
using System.Net.Mail;

namespace EmailService
{
    public class EmailSender
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            // Replace with your SMTP server details (if yahoo = "smtp.yahoo.com")
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587; // Port for TLS
            string smtpUsername = "tewahidotefera42@gmail.com";
            string smtpPassword = "wiyq urrb ubbn dzof"; // 2FA must be on, generate "App Password" on google account

            try
            {
                // Log SMTP client configuration
                Console.WriteLine($"Attempting to send email from {smtpUsername} to {toEmail}");

                // Configure the SMTP client
                using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true; // Enable SSL/TLS for secure email sending
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; // Use network delivery

                    // Create the email message
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(smtpUsername),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false, // Optional: If the body contains HTML or false if not
                    };
                    mailMessage.To.Add(toEmail);

                    // Log message before sending
                    Console.WriteLine($"Sending email with subject: {subject}");

                    // Send the email
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Email sent successfully.");
                }
            }
            catch (SmtpException ex)
            {
                // Log SMTP specific errors
                Console.WriteLine($"SMTP Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Check for inner exception if it exists
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    Console.WriteLine($"Inner Exception Stack Trace: {ex.InnerException.StackTrace}");
                }

                // Check for SMTP status code (if available)
                if (ex.StatusCode != null)
                {
                    Console.WriteLine($"SMTP Status Code: {ex.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log general exceptions
                Console.WriteLine($"General Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}
