using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class ListaSeparacao
    {
        [Key]
        public Int64 ListaSeparacaoId { get; set; }

        [Display(Name = "Lista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(12, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string ListaNum { get; set; }

        [Display(Name = "Sequência Lista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(5, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string ListaSeq { get; set; }

        [Display(Name = "Prioridade Lista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        //[StringLength(5, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public Int64 PrioriadeId { get; set; }

        [Display(Name = "Código Material")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(40, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string MaterialCod { get; set; }

        [Display(Name = "Descrição Material")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(120, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string MaterialDes { get; set; }

        [Display(Name = "Código Endereço")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(10, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string EnderecoCod { get; set; }

        [Display(Name = "Descrição Endereço")]
        [DataType(DataType.Text)]
        public string EnderecoDes { get; set; }

        [Display(Name = "Quantidade Solicitada")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(10, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string QtdeSolicitada { get; set; }

        [Display(Name = "Quantidade Separada")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(10, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 0)]
        [DataType(DataType.Text)]
        public string QtdeSeparada { get; set; }

        [Display(Name = "Data início")]
        [DataType(DataType.DateTime)]
        public string DhInicio { get; set; }

        [Display(Name = "Data Fim")]
        [DataType(DataType.DateTime)]
        public string DhFim { get; set; }

        [Display(Name = "FgExclusivo")]
        [DataType(DataType.Text)]
        public string FgExclusivo { get; set; }

        //A - Andamento
        //L - Liberado para separar(aguardando inicio)
        //C - Cancelado
        //F - Fechado
        //I - Inconformidade
        [Display(Name = "FgStatus")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string FgStatus { get; set; }

        //permite(S/N) separar quantidade divergente.
        [Display(Name = "FgQtdeSeparada")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string FgQtdeSeparada { get; set; }

        [Display(Name = "Data Alteração")]
        [DataType(DataType.DateTime)]
        public string DhAlteração { get; set; }

        public virtual Usuario UserId { get; set; }
    }
}