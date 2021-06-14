using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class Documento
    {
        [Key]
        public Int64 DocumentoId { get; set; }

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
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

    }
}