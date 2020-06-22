using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Core
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _configuration;

        public EmailSender(EmailConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        //Contact Us Mail Settings
        public async Task SendMailAsync(ContactUsMessage message)
        {
            var emailMessage =  CreateEmailMessage(message);
            
            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(ContactUsMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            
            
            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = string.Format($"<h2>Hi, I'm {message.Name}</h2>\n<br/>" +
                                         $"<p>Email: {message.Email}</p>\n<br/>" +
                                         $"<p>{message.Content}</p>\n<br/>" +
                                         "Thank you")
            };

            if (message.AttachmentFiles != null && message.AttachmentFiles.Any())
            {
                byte[] fileBytes;
                foreach (var file in message.AttachmentFiles)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        //End of Code
        
        
        //Help And Donation Settings
        public async Task SendMailAsync(HelpAndDonationMessage message)
        {
            var emailMessage = CreateEmailMessage(message);

            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(HelpAndDonationMessage message)
        {
            var emailMessage = new MimeMessage();
            
            emailMessage.From.Add(new MailboxAddress(_configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = "Help And Donation";

            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = string.Format($"<h2>Name: {message.Name}</h2>\n<br/>" +
                                         $"<p>Email: {message.Email}</p>\n<br/>" +
                                         $"<p>Phone Number: {message.PhoneNumber}</p>\n<br/>" +
                                         $"<p>Id Number: {message.IdNumber}</p>\n<br/>" +
                                         $"<p>Pensioner Confirmation: {message.PensionerConfirmation}</p>\n<br/>" +
                                         $"<p>Number of Family Members: {message.NumberOfFamily}</p>\n<br/>" +
                                         $"<p>Province: {message.Province}</p>\n<br/>" +
                                         $"<p>Employment Status: {message.EmploymentStatus}</p>\n<br/>" +
                                         $"<p>{message.Message}</p>\n<br/>" +
                                         "Thank you")
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();
            
            return emailMessage;
        }
        
        //End of Code
        
        //Code for Broker Page
        public async Task SendMailAsync(BrokerMessage message)
        {
            var emailMessage =  CreateEmailMessage(message);
            
            await SendAsync(emailMessage);
        }



        private MimeMessage CreateEmailMessage(BrokerMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = "Broker Inquiry";
            
            
            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = string.Format($"<h2>Hi, I'm {message.Name}</h2>\n<br/>" +
                                         $"<p>Email: {message.Email}</p>\n<br/>" +
                                         $"<p>Number: {message.Number}</p>\n<br/>" +
                                         $"<p>Service Provider:{message.ServiceProvider}</p>\n<br/>" +
                                         "Thank you")
            };

            if (message.AttachmentFiles != null && message.AttachmentFiles.Any())
            {
                byte[] fileBytes;
                foreach (var file in message.AttachmentFiles)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        //End of Code
        
        //Intermediary Broker
        public async Task SendMailAsync(IntermediaryMessage message)
        {
            var emailMessage =  CreateEmailMessage(message);
            
            await SendAsync(emailMessage);
        }

        

        private MimeMessage CreateEmailMessage(IntermediaryMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = "Intermediary Broker Inquiry";
            
            
            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = string.Format($"<h2>Hi, I'm {message.Name}</h2>\n<br/>" +
                                         $"<p>Email: {message.Email}</p>\n<br/>" +
                                         $"<p>Number: {message.PhoneNumber}</p>\n<br/>" +
                                         "Thank you")
            };

            if (message.AttachmentFiles != null && message.AttachmentFiles.Any())
            {
                byte[] fileBytes;
                foreach (var file in message.AttachmentFiles)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        //End of code
        
        //Service Provider Message
        public async Task SendMailAsync(ServiceProviderMessage message)
        {
            var emailMessage = CreateEmailMessage(message);

            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(ServiceProviderMessage message)
        {
            var emailMessage = new MimeMessage();
            
            emailMessage.From.Add(new MailboxAddress(_configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = "Service Provider Inquiry";

            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = string.Format($"<h2>Name: {message.Name}</h2>\n<br/>" +
                                         $"<p>Email: {message.Email}</p>\n<br/>" +
                                         $"<p>Phone Number: {message.PhoneNumber}</p>\n<br/>" +
                                         $"<p>Company Name: {message.CompanyName}</p>\n<br/>" +
                                         $"<p>Website: {message.Website}</p>\n<br/>" +
                                         $"<p>involvement: {message.Involvement}</p>\n<br/>" +
                                         $"<p>{message.Message}</p>\n<br/>" +
                                         "Thank you")
            };

            if (message.AttachmentFiles != null && message.AttachmentFiles.Any())
            {
                byte[] fileBytes;
                foreach (var file in message.AttachmentFiles)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        //End of Code
        
        //Code for Sending an Email
        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.SmtpServer, _configuration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_configuration.Username, _configuration.Password);

                    client.Send(mailMessage);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
        //End of code
    }
}