using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class EmailContent
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
}