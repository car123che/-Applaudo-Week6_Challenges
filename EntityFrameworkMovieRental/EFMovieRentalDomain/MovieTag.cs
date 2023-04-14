using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMovieRentalDomain
{
    public class MovieTag: BaseDomain
    {
        public int MovieId { get; set; }
        public int TagId { get; set; }

        public virtual Movie Movie { get; set; } 
        public virtual Tag Tag { get; set; }
    }
}
