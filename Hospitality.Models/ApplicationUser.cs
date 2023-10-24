using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitality.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Username { get; set; }

    }
}
