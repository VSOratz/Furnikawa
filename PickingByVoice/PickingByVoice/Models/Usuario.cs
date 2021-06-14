using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PickingByVoice.Models
{
    public class Usuario
    {
        [Key]
        public int USERID { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [Index("UserNameIndex", IsUnique = true)]
        public string USERNAME { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 2)]
        public string NOME { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 2)]
        public string SOBRENOME { get; set; }

        [Display(Name = "Usuário")]
        public string NOMECOMPLETO { get { return string.Format("{0} {1}", this.NOME, this.SOBRENOME); } }
        
        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        public string PHOTO { get; set; }
        
        //public virtual ICollection<Grupos> Grupos { get; set; }

        //public virtual ICollection<GruposDetalhes> GruposDetalhes { get; set; }

    }
}