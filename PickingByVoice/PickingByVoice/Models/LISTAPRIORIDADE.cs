using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class LISTAPRIORIDADE
    {
        [Key]
        public Int64 PRIORIDADEID { get; set; }

        [Display(Name = "Lista ID")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public Int64 LISTAID { get; set; }

        [Display(Name = "Prioridade Lista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        //[StringLength(12, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public int PRIORIDADELISTA { get; set; }

        [Display(Name = "SgUser")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string SGUSER { get; set; }

        [Display(Name = "Data Manutenção")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string DTMANUTENCAO { get; set; }
    }
}