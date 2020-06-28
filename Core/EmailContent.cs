using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class ContactusEmailContent
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string RequestType { get; set; }

        [Required]
        public string Message { get; set; }
    }

    public class HelpAndDonationContent
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public string PensionerConfirmation { get; set; }

        [Required]
        public string NumberOfFamilyMembers { get; set; }

        [Required]
        public string Province { get; set; }
        
        [Required]
        public string EmploymentStatus { get; set; }

        [Required]
        public string Message { get; set; }
    }

    public class BrokerContent
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Provider { get; set; }
    }

    public class IntermediaryContent
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }

    public class ServiceProvider
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Involvement { get; set; }
    }
}