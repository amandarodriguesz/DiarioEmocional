using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioEmocional.Models
{
    public class Usuario : IdentityUser
    {
        //public byte[] PhotoFile { get; set; }
        //public string ImageName { get; set; }

        public string PsicoterapeutaID { get; set; }
        public string RoleName { get; set; }
        
    }
}
