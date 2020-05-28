using System;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmailAsync()
        {
            // var test = "success";
            // var message = new Message(new string[] { "jthurling78@gmail.com" }, "Test email", "This is the content from our email.",null);
            // await _emailSender.SendMailAsync(message);
        
            return Ok();
        }

        // [HttpPost]
        // public async Task<ActionResult> GetEmailWIthAttachments()
        // {
        //     var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
        //     
        //     var message = new Message(new string[] { "jthurling78@gmail.com" }, "Test email", "This is the content from our email.", files);
        //     await _emailSender.SendMailAsync(message);
        //
        //     return Ok();
        // }

        [HttpPost]
        public async Task<ActionResult<EmailContent>> Post( [FromForm] EmailContent emailContent)
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            if (!files.Any())
            {
                files = null;
            }
            
            var email = emailContent.Email;
            var request = emailContent.RequestType;
            var messageBody = emailContent.Message;
            var name = emailContent.Name;
            
            var message = new Message(new[] { "jthurling78@gmail.com" }, request, name, email, messageBody, files);
            await _emailSender.SendMailAsync(message);

            return Ok();
        }
    } }