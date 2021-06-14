using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class PEDIDO_ITEM
    {
        [Key]
        public int PedidoMestre_ID { get; set; }

        [Display(Name = "Sequencia Pedido")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public decimal SeqPedido { get; set; }

        [Display(Name = "Código Produto")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string cdProduto { get; set; }

        [Display(Name = "Descrição Produto")]
        [StringLength(255, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string DsProduto { get; set; }

        [Display(Name = "Quantidade Solicitado")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public decimal QtdeSolicitado { get; set; }

        [Display(Name = "Quantidade Atendido")]
        [DataType(DataType.Text)]
        public decimal QtdeAtendido { get; set; }

        [Display(Name = "Codigo Fabricante")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string CdFabricante { get; set; }

        [Display(Name = "Numero Lote")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string NumeroLote { get; set; }

        [Display(Name = "data Validade")]
        [DataType(DataType.DateTime)]
        public DateTime DtValidade { get; set; }

        [Display(Name = "data Fabricacao")]
        [DataType(DataType.DateTime)]
        public DateTime DtFabricacao { get; set; }

        [Display(Name = "data Fim")]
        [DataType(DataType.DateTime)]
        public DateTime DtFim { get; set; }

        [Display(Name = "data Saida Material ")]
        [DataType(DataType.Text)]
        public string DtSaidaMaterial { get; set; }

        [Display(Name = "Flag Situação")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char FgSituacao { get; set; }

        [Display(Name = "Descrição Endereco")]
        [StringLength(255, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string DsEndereco { get; set; }
        
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