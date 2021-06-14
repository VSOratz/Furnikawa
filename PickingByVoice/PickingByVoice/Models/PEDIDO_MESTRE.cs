using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class PEDIDO_MESTRE
    {
        [Key]
        public int PEDIDOMESTRE_ID{ get; set; }

        [Display(Name = "Data Emissão")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public DateTime DtEmissao { get; set; }

        [Display(Name = "Data Coleta")]
        [DataType(DataType.DateTime)]
        public DateTime DtColeta { get; set; }

        [Display(Name = "Valor Total")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public Decimal VlTotal { get; set; }

        [Display(Name = "Fg Situação")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char FGSituacao{ get; set; }

        [Display(Name = "Nome Operador")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string NmOperador { get; set; }

        [Display(Name = "Data Inicio")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public DateTime DtInicio { get; set; }

        [Display(Name = "Data Fim")]
        [DataType(DataType.DateTime)]
        public DateTime DtFim { get; set; }

        [Display(Name = "Data Limite")]
        [DataType(DataType.DateTime)]
        public DateTime DtLimite { get; set; }

        [Display(Name = "Data Cancelamento")]
        [DataType(DataType.DateTime)]
        public DateTime DtCancelamento { get; set; }

        [Display(Name = "Tipo Venda")]
        [DataType(DataType.Text)]
        public char FGVenda { get; set; }

        [Display(Name = "Arquivo EDI")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char FGArquivoEDI { get; set; }

        [Display(Name = "Nome Arquivo")]
        [StringLength(255, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char NmArquivo { get; set; }

        [Display(Name = "SgUser")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string SgUser { get; set; }

        [Display(Name = "Data Manutenção")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string DtManutencao { get; set; }

    }
}