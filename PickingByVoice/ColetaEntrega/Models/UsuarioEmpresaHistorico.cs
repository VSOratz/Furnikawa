using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class UsuarioEmpresaHistorico
    {
        [Key]
        public int UsuarioEmpresaHistoricoId { get; set; }

        [Display(Name = "Data Interação")]
        [DataType(DataType.DateTime)]
        public DateTime DhInteracao { get; set; }

        [Display(Name = "Rota da Interação")]
        [DataType(DataType.Text)]
        public string RotaInteracao { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public int ParticipanteId { get; set; }
        [ForeignKey("ParticipanteId")]
        public virtual Participante Participante { get; set; }

    }
}