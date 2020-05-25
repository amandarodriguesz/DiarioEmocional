using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioEmocional.Models
{
    public class Registro : Entity
    {
        [DisplayName("Emoção")]
        public int EmocaoID { get; set; }
        [DisplayName("Intensidade")]
        public int IntensidadeID { get; set;}
        [DisplayName("Situação")]
        public string Situacao { get; set; }
        [DisplayName("Comportamento")]
        public string Comportamento { get; set; }

        public bool EnviarPsicoterapeuta { get; set; }

        public bool LidoPsicoterapeuta { get; set; }

        public virtual Emocao Emocao { get; set; }
        public virtual Intensidade Intensidade { get; set; }
    }
}
