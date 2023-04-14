using System.ComponentModel.DataAnnotations;

namespace MoviRentalApi.Models
{
    public class SellData
    {
        [Required]
        public int moveiId { get; set; }

        [Required]
        public int userId { get; set; }
    }
}
