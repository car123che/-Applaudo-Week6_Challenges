using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MoviRentalApi.Models
{
    public class TagData 
    {
        [Required]
        public string Name { get; set; }

    }
}
