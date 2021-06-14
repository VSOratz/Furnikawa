using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class EdiImportaMestre
    {
        [Key]
        public int EdiImportaMestreId { get; set; }

        [Display(Name = "Data Importação")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public DateTime DtImportacao { get; set; }

        [Display(Name = "Nome Arquivo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(150, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 2)]
        public string NmArquivo { get; set; }

        //A - ABERTO
        //L - LISTA
        //C - CANCELADO
        //I - IMPORTADO
        [Display(Name = "Status")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string Status { get; set; }

        [Display(Name = "SgUser")]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string SgUser { get; set; }

        [Display(Name = "Data Manutenção")]
        [DataType(DataType.DateTime)]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public DateTime DtManutencao { get; set; }
    }
}