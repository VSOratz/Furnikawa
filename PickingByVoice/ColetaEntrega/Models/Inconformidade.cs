using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class Inconformidade
    {
        [Key]
        public int InconformidadeId { get; set; }

        [Display(Name = "Sequência Inconformidade")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(12, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string InconformidadeSeq { get; set; }

        [Display(Name = "Sequência Lista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(12, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string ListaSeq { get; set; }

        [Display(Name = "Código Material")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(40, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string MaterialCod { get; set; }

        [Display(Name = "Quantidade Separada")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(10, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 0)]
        [DataType(DataType.Text)]
        public string QtdeSeparada { get; set; }

        [Display(Name = "Data Inconformidade")]
        [DataType(DataType.DateTime)]
        public string DhInconformidade { get; set; }

        [Display(Name = "FgEnviado")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string FgEnviado { get; set; }

        public int ItemColetaId { get; set; }

        public int InconformidadeTipoId { get; set; }

        [ForeignKey("ItemColetaId")]
        public virtual ItemColeta ItemColeta { get; set; }

        [ForeignKey("InconformidadeTipoId")]
        public virtual InconformidadeTipo inconformidadeTipo { get; set; }

        //public virtual ICollection<Documento> Documento { get; set; }
    }
}