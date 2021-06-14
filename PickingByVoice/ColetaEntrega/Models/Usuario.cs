using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        /// <summary>
        /// A - Ativo
        /// I - Inativo
        /// </summary>
        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [DataType(DataType.Text)]
        public string Ativo { get; set; }

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

        public int ParticipanteId { get; set; }
        [ForeignKey("ParticipanteId")]
        public virtual Participante Participante { get; set; }
    }
}