using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class MestreColeta
    {
        [Key]
        public int MestreColetaId { get; set; }

        [Display(Name = "Número Romaneio")]
        [DataType(DataType.Text)]
        public string NrRomaneio { get; set; }

        [Display(Name = "Placa do Veículo")]
        [DataType(DataType.Text)]
        public string Placa { get; set; }

        [Display(Name = "Data Coleta")]
        [DataType(DataType.DateTime)]
        public DateTime Previsao_Retorno { get; set; }

        //A = ABERTO
        //E = EM ANDAMENTO
        //I = INICIADO
        //C = CANCELADO
        //R = REJEITADO
        //F = FINALIZADO
        [Display(Name = "Status da Coleta")]
        [DataType(DataType.Text)]
        public string Status_Coleta { get; set; }

        [Display(Name = "SgUser")]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string SgUser { get; set; }

        [Display(Name = "Data Manutenção")]
        [DataType(DataType.DateTime)]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public DateTime DtManutencao { get; set; }

        public int ParticipanteId { get; set; } //motorista
        [ForeignKey("ParticipanteId")]
        public virtual Participante Participante { get; set; }
        public virtual ICollection<ItemColeta> ItemColeta { get; set; }
    }
}