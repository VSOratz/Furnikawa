using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class Documento
    {
        [Key]
        public int DocumentoId { get; set; }

        [Display(Name = "Número Documento")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(12, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string DocumentoNum { get; set; }

        [Display(Name = "Sequência Documento")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(12, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string DocumentoSeq { get; set; }

        [Display(Name = "Foto")]
        [DataType(DataType.Upload)]
        public byte[] Photo { get; set; }

        public int ItemColetaId { get; set; }

        [ForeignKey("ItemColetaId")]
        public virtual ItemColeta ItemColeta { get; set; }

        //public int InconformidadeId { get; set; }

        //[ForeignKey("InconformidadeId")]
        //public virtual Inconformidade Inconformidade { get; set; }
    }
}