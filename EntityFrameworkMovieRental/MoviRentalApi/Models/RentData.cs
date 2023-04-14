using System.ComponentModel.DataAnnotations;

namespace MoviRentalApi.Models
{
    public class RentData
    {
        [Required]
        public int moveiId { get; set; }

        [Required]
        public int userId { get; set; }
    }
}
