using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safar.UIService.Dto
{
    public class TravelAgencyDto
    {
        public int Id { get; set; }

        public int VerifiedUserId { get; set; }

        public int UsersCategoryId { get; set; }

        public string Name { get; set; }

        public string Abbrevivation { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Deleted { get; set; }

        public virtual UsersCategoryDto UsersCategory { get; set; }

        public virtual VerifiedUserDto VerifiedUser { get; set; }
    }
}
