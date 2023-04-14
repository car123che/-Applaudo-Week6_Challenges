using System.ComponentModel.DataAnnotations;

namespace MoviRentalApi.Models
{
    public class MovieData
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int PosterStock { get; set; }

        [Required]
        public string TrailerLink { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double SalePrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Likes { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Availability { get; set; }
    }
}
