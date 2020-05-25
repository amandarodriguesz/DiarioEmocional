using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioEmocional.ModelView
{
    public class PacienteModelView
    {
        //public byte[] PhotoFile { get; set; }
        //public string ImageName { get; set; }

        public string RoleName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PsicoterapeutaId { get; set; }
        public string Name { get; set; }

    }
}
