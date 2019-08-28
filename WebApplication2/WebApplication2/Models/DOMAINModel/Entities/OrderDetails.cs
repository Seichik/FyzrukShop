using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.DOMAINModel.Entities
{
    public class OrderDetails
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select your country.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please select your city.")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please enter your email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter your phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}