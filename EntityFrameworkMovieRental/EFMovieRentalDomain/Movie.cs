using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMovieRentalDomain
{
    public class Movie: BaseDomain
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PosterStock { get; set; }
        public string TrailerLink { get; set; }
        public double SalePrice { get; set; }
        public int Likes { get; set; }
        public int Availability { get; set; }

    }
}
