using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class ItemColeta
    {
        [Key]
        [Display(Name = "ID Item Coleta")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public int ItemColetaId { get; set; }

        [Display(Name = "Data Coleta")]
        [DataType(DataType.DateTime)]
        public DateTime DhColeta { get; set; }

        [Display(Name = "CNPJ Empresa Destino")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string CnpjEmpresaDestino { get; set; }

        [Display(Name = "Nome/Fantasia Empresa Destino")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string EmpresaDestino { get; set; }

        [Display(Name = "Rua")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Rua { get; set; }

        [Display(Name = "Numero")]
        [DataType(DataType.Currency)]
        public decimal Numero { get; set; }

        [Display(Name = "Complemento")]
        [DataType(DataType.Text)]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        [DataType(DataType.Text)]
        public string Bairro { get; set; }

        [Display(Name = "Valor da Carga")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public decimal Valor { get; set; }

        [Display(Name = "Quantidade da Carga")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public decimal Quantidade { get; set; }

        [Display(Name = "Peso da Carga")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public decimal Peso { get; set; }

        [Display(Name = "Número da NF-e da Carga")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public decimal Nota { get; set; }

        [Display(Name = "Tipo Coleta/Entrega")]
        [DataType(DataType.Text)]
        public string Tipo_Coleta { get; set; }

        //A = ABERTO
        //E = EM ANDAMENTO
        //I = INICIADO
        //C = CANCELADO
        //R = REJEITADO
        //F = FINALIZADO
        [Display(Name = "Status da Coleta")]
        [DataType(DataType.Text)]
        public string Status_Coleta { get; set; }

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

        [Display(Name = "Data Manutenção")]
        [DataType(DataType.DateTime)]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public DateTime DtManutencao { get; set; }

        public int MestreColetaId { get; set; }
        //public int InconformidadeId { get; set; }
        //public int DocumentoId { get; set; }
        public int ParticipanteId { get; set; } //empresa destino
        [ForeignKey("ParticipanteId")]
        public virtual Participante Participante { get; set; }

        [ForeignKey("MestreColetaId")]
        public virtual MestreColeta MestreColeta { get; set; }

        //[ForeignKey("InconformidadeId")]
        public virtual ICollection<Inconformidade> Inconformidade { get; set; }
        //[ForeignKey("DocumentoId")]
        public virtual ICollection<Documento> Documento { get; set; }
    }
}