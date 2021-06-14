using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class ItemColetaMovimentacao
    {
        [Key]
        public int itemColetaMovimentacaoId { get; set; }//nossa sequencia de movimentos

        public int ItemColetaId { get; set; }

        [Display(Name = "Status da Movimentacao")]
        [DataType(DataType.Text)]
        public string StatusMovimentacao { get; set; }

        [Display(Name = "Descrição da Movimentacao")]
        [DataType(DataType.Text)]
        public string DescricaoMovimentacao { get; set; }

        [Display(Name = "Data Inclusão")]
        [DataType(DataType.DateTime)]
        public DateTime DhInclusao { get; set; }

        [Display(Name = "Latitude")]
        [DataType(DataType.Text)]
        public string Latitude { get; set; }

        [Display(Name = "Longetude")]
        [DataType(DataType.Text)]
        public string Longetude { get; set; }

        [Display(Name = "SgUser")]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string SgUser { get; set; }

        [ForeignKey("ItemColetaId")]
        public virtual ItemColeta ItemColeta { get; set; }
    }
}