using System.ComponentModel.DataAnnotations;

namespace MoviRentalApi.Models
{
    public class MovieTagData
    {
        [Required]
        public int moveiId { get; set; }

        [Required]
        public int tagId { get; set; }
    }
}
