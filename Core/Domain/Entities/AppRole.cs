using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppRole : BaseEntity
    {
        public string AppRoleName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
