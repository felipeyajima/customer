using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Data.Dto
{
    public class CreateCustomerDto
    {

        [Required]
        [MaxLength(99, ErrorMessage = "The name of the customer cant have more than 99 characters")]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "the email address needs to have more than 10 characters")]
        public string Email { get; set; }
    }
}
