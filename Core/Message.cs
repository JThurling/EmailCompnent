using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public IFormFileCollection AttachmentFiles { get; set; }

        public Message(IEnumerable<string> to, string subject, string name, string email ,string content, IFormFileCollection files)
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
}