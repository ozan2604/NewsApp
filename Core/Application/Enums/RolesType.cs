using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enums
{
    public class RolesType
    {
        public static readonly Guid Admin = Guid.Parse("f8f1431b-0e62-4abc-a784-8e953dfed910");
        public static readonly Guid Member = Guid.Parse("ec082fa1-b6ef-4b68-b977-86bd9fcf9f4a");
        public static readonly Guid Author = Guid.Parse("22b17cd0-19f3-4d74-999d-867287b54b56");

    }
}
