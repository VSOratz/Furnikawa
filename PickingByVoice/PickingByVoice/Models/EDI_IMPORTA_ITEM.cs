using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class EDI_IMPORTA_ITEM
    {
        [Key]
        public int ID_IMPORTAITEM { get; set; }
        //[Key]W
        public int ID_IMPORTAMESTRE { get; set; }

        [Display(Name = "Sequência Item")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        //[Key]
        public double SEQITEM { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string STATUS { get; set; }

        [Display(Name = "Código Produto")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string CDPRODUTO { get; set; }

        [Display(Name = "Descrição Produto")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string DESCPRODUTO { get; set; }

        [Display(Name = "Unidade")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(5, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string SGUNIDADE { get; set; }

        [Display(Name = "Lote")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string LOTEPRODUTO { get; set; }

        [Display(Name = "Código Marca")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string CDMARCA { get; set; }

        [Display(Name = "Descrição Marca")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string DESCMARCA { get; set; }

        [Display(Name = "Código Fabricante")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string CDFABRICANTE { get; set; }

        [Display(Name = "Código Fornecedor")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string CDFORNECEDOR { get; set; }

        [Display(Name = "Nome Fornecedor")]
        [StringLength(150, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string NMFORNECEDOR { get; set; }

        [Display(Name = "Quantidade Pedido")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public double? QTPEDIDO { get; set; }

        [Display(Name = "Peso Liquido")]
        public double? PESOLIQ { get; set; }

        [Display(Name = "Peso Bruto")]
        public double? PESOBRUTO { get; set; }

        [Display(Name = "Data Vencimento")]
        [DataType(DataType.DateTime)]
        public DateTime? DTVENCIMENTO { get; set; }

        [Display(Name = "Data Fabricação")]
        [DataType(DataType.DateTime)]
        public DateTime? DTFABRICACAO { get; set; }

        [Display(Name = "Código Embalagem")]
        [StringLength(15, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [DataType(DataType.Text)]
        public string CDEMBALAGEM { get; set; }

        [Display(Name = "Sequencia Embalagem")]
        [StringLength(15, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [DataType(DataType.Text)]
        public string SEQEMBALAGEM { get; set; }

        [Display(Name = "Quantidade Embalagem")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public double? QTEMBALAGEM { get; set; }

        [Display(Name = "Tipo Embalagem")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string TPEMBALAGEM { get; set; }

        [Display(Name = "Número Pedido")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public double? NRPEDIDO { get; set; }

        [Display(Name = "Número Lista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public double? NRLISTA { get; set; }

        [Display(Name = "Data Limite")]
        [DataType(DataType.DateTime)]
        public DateTime? DTLIMITE { get; set; }

        [Display(Name = "Descrição Endereço")]
        [StringLength(150, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [DataType(DataType.Text)]
        public string DESCENDERECO { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string FGATIVO { get; set; }

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