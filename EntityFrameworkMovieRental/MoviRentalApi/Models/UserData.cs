using System.ComponentModel.DataAnnotations;

namespace MoviRentalApi.Models
{
    public class UserData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
