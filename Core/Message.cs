using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    //Contact Us Message Class
    public class ContactUsMessage
    {
        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public IFormFileCollection AttachmentFiles { get; set; }

        public ContactUsMessage(IEnumerable<string> to, string subject, string name, string email ,string content, IFormFileCollection files)
        {
            To = new List<MailboxAddress>();
            
            To.AddRange(to.Select(x => new MailboxAddress(x)));

            Subject = subject;
            Name = name;
            Email = email;
            Content = content;

            AttachmentFiles = files;
        }
    }
    
    //Help And Donation Message Class
    public class HelpAndDonationMessage
    {
        public List<MailboxAddress> To { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string IdNumber { get; set; }

        public string PensionerConfirmation { get; set; }

        public string Province { get; set; }

        public string NumberOfFamily { get; set; }

        public string EmploymentStatus { get; set; }

        public string Message { get; set; }

        public HelpAndDonationMessage(
            IEnumerable<String> to,
            string name,
            string email,
            string phoneNumber,
            string idNumber,
            string pensionerConfirmation,
            string numberOfFamily,
            string province,
            string employmentStatus,
            string message
            )
        {
            To = new List<MailboxAddress>();
            
            To.AddRange(to.Select(x => new MailboxAddress(x)));

            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            IdNumber = idNumber;
            PensionerConfirmation = pensionerConfirmation;
            NumberOfFamily = numberOfFamily;
            Province = province;
            EmploymentStatus = employmentStatus;
            Message = message;
        }
    }
    //End of Code
    
    //Broker Email Message
    public class BrokerMessage
    {
        public List<MailboxAddress> To { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ServiceProvider { get; set; }

        public IFormFileCollection AttachmentFiles { get; set; }

        public BrokerMessage(IEnumerable<string> to, string name, string email ,string serviceProvider, string number, IFormFileCollection files)
        {
            To = new List<MailboxAddress>();
            
            To.AddRange(to.Select(x => new MailboxAddress(x)));

            Number = number;
            Name = name;
            Email = email;
            ServiceProvider = serviceProvider;

            AttachmentFiles = files;
        }
    }

    public class IntermediaryMessage
    {
        public List<MailboxAddress> To { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFileCollection AttachmentFiles { get; set; }

        public IntermediaryMessage(IEnumerable<string> to, string name, string email ,string phoneNumber, IFormFileCollection files)
        {
            To = new List<MailboxAddress>();
            
            To.AddRange(to.Select(x => new MailboxAddress(x)));

            PhoneNumber = phoneNumber;
            Name = name;
            Email = email;

            AttachmentFiles = files;
        }
    }

    public class ServiceProviderMessage
    {
        public List<MailboxAddress> To { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CompanyName { get; set; }

        public string Website { get; set; }
        public string Message { get; set; }
        
        public string Involvement { get; set; }
        
        public IFormFileCollection AttachmentFiles { get; set; }

        public ServiceProviderMessage(
            IEnumerable<String> to,
            string name,
            string email,
            string phoneNumber,
            string companyName,
            string website,
            string message,
            string involvement,
            IFormFileCollection files
        )
        {
            To = new List<MailboxAddress>();
            
            To.AddRange(to.Select(x => new MailboxAddress(x)));

            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            CompanyName = companyName;
            Website = website;
            Involvement = involvement;
            AttachmentFiles = files;
            Message = message;
        }
    }
}