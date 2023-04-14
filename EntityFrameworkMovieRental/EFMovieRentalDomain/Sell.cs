using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMovieRentalDomain
{
    public class Sell: BaseDomain
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string SellDate { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }

    }
}
