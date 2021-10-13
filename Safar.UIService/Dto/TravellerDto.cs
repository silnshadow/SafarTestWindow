using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safar.UIService.Dto
{
    public class TravellerDto
    {
        public int Id { get; set; }

        public int VerifiedUserId { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Deleted { get; set; }

        public int UsersCategoryId { get; set; }

        public virtual VerifiedUserDto VerifiedUser { get; set; }
    }
}
