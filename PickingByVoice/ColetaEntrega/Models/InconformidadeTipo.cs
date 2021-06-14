using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class InconformidadeTipo
    {
        [Key]
        public int InconformidadeTipoId { get; set; }

        [Display(Name = "Descrição Inconformidade")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1}")]
        [DataType(DataType.Text)]
        public string dsTipo { get; set; }
    }
}