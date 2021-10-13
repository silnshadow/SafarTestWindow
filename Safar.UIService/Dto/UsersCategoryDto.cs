using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safar.UIService.Dto
{
    public class UsersCategoryDto
    {
        public UsersCategoryDto()
        {
            TravelAgencies = new HashSet<TravelAgencyDto>();
            VerifiedUsers = new HashSet<VerifiedUserDto>();
        }

        public int Id { get; set; }

        public string Category { get; set; }

        public virtual ICollection<TravelAgencyDto> TravelAgencies { get; set; }

        public virtual ICollection<VerifiedUserDto> VerifiedUsers { get; set; }
    }
}
