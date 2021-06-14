using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class UsuarioEmpresa
    {
        [Key, Column(Order = 0)]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Tem que ser de um participante com a flag fgEmpresa = S
        /// </summary>
        [Key, Column(Order = 1)]
        public int ParticipanteId { get; set; }

        [Display(Name = "Data Criação")]
        [DataType(DataType.DateTime)]
        public DateTime DhCriacao { get; set; }

        [Display(Name = "Nome Usuário que Criou")]
        [DataType(DataType.Text)]
        public string NmUsuarioCriou { get; set; }

        [Display(Name = "Data Alteração")]
        [DataType(DataType.DateTime)]
        public DateTime DhAlteracao { get; set; }

        [Display(Name = "Nome Usuário que Alterou")]
        [DataType(DataType.Text)]
        public string NmUsuarioAlterou { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}