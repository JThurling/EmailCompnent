using System;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Site-wide Email Controller
namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        //Contact Us Page Email Controller
        [HttpPost("contactUs")]
        public async Task<ActionResult<ContactusEmailContent>> ContactUsPost( [FromForm] ContactusEmailContent emailContent)
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
            
            var message = new ContactUsMessage(new[] { "jthurling78@gmail.com" }, request, name, email, messageBody, files);
            await _emailSender.SendMailAsync(message);

            return Ok();
        }

        //Help and Donation Page
        [HttpPost("donation")]
        public async Task<ActionResult<HelpAndDonationContent>> DonationPost( [FromForm] HelpAndDonationContent content )
        {
            var name = content.Name;
            var email = content.Email;
            var phoneNumber = content.PhoneNumber;
            var idNumber = content.IdNumber;
            var pensioner = content.PensionerConfirmation;
            var numberOfFamily = content.NumberOfFamilyMembers;
            var province = content.Province;
            var employment = content.EmploymentStatus;
            var messageBody = content.Message;
            
            var mail = new HelpAndDonationMessage(
                new [] { "jthurling78@gmail.com" },
                name,
                email,
                phoneNumber,
                idNumber,
                pensioner,
                numberOfFamily,
                province,
                employment,
                messageBody
                );

            await _emailSender.SendMailAsync(mail);
            return Ok();
        }
        
        //Broker Page
        [HttpPost("broker")]
        public async Task<ActionResult<BrokerContent>> BrokerPost( [FromForm] BrokerContent content )
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            if (!files.Any())
            {
                files = null;
            }
            
            var email = content.Email;
            var serviceProvider = content.Provider;
            var number = content.PhoneNumber;
            var name = content.Name;
            
            var message = new BrokerMessage(new[] { "jthurling78@gmail.com" }, name, email, serviceProvider, number, files);
            await _emailSender.SendMailAsync(message);

            return Ok();
        }
        
        //Intermediary Broker Page
        [HttpPost("intermediaryBroker")]
        public async Task<ActionResult<IntermediaryContent>> IntermediaryBrokerPost( [FromForm] IntermediaryContent content )
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            if (!files.Any())
            {
                files = null;
            }
            
            var email = content.Email;
            var number = content.PhoneNumber;
            var name = content.Name;
            
            var message = new IntermediaryMessage(new[] { "jthurling78@gmail.com" }, name, email, number, files);
            await _emailSender.SendMailAsync(message);

            return Ok();
        }
        
        //Service provider Page
        [HttpPost("serviceProvider")]
        public async Task<ActionResult<ServiceProvider>> ServiceProviderPost( [FromForm] ServiceProvider content)
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            if (!files.Any())
            {
                files = null;
            }
            
            var name = content.Name;
            var email = content.Email;
            var companyName = content.CompanyName;
            var number = content.Number;
            var website = content.Website;
            var message = content.Message;
            var involvement = content.Involvement;
            
            var mail = new ServiceProviderMessage(
                new [] { "jthurling78@gmail.com" },
                name,
                email,
                number,
                companyName,
                website,
                message,
                involvement,
                files
            );

            await _emailSender.SendMailAsync(mail);
            return Ok();
        }
    } }