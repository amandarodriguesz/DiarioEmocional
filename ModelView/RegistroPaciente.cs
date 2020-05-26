using DiarioEmocional.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioEmocional.ModelView
{
    public class RegistroPaciente
    {
        [Display(Name = "Id")]
        public int ID { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UsuarioInclusao { get; set; }
        public string UsuarioAlteracao { get; set; }
        [DisplayName("Emoção")]
        public int EmocaoID { get; set; }
        [DisplayName("Intensidade")]
        public int IntensidadeID { get; set; }
        [DisplayName("Situação")]
        public string Situacao { get; set; }
        [DisplayName("Comportamento")]
        public string Comportamento { get; set; }

        public bool EnviarPsicoterapeuta { get; set; }

        public bool LidoPsicoterapeuta { get; set; }

        public string NomePaciente { get; set; }
        public virtual Emocao Emocao { get; set; }
        public virtual Intensidade Intensidade { get; set; }
    }
}
