using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SystemUser : Entity
    {
        // A separate class was created to represent the system user, which is a base class for both authors and readers.
        // this class is extendable to include emails, passwords, and other user information.
        public string Name { get; set; }

    }
}
