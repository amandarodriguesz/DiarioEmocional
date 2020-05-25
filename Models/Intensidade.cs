using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioEmocional.Models
{
    public class Intensidade: Entity
    {
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Registro> Registros { get; set; }

    }
}
