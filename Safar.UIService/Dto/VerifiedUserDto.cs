using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safar.UIService.Dto
{
    public class VerifiedUserDto
    {
        public VerifiedUserDto()
        {
            TravelAgencies = new HashSet<TravelAgencyDto>();
            Travellers = new HashSet<TravellerDto>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Deleted { get; set; }

        public int? UsersCategoryId { get; set; }

        public virtual ICollection<TravelAgencyDto> TravelAgencies { get; set; }

        public virtual ICollection<TravellerDto> Travellers { get; set; }

        public virtual UsersCategoryDto UsersCategory { get; set; }
    }
}
