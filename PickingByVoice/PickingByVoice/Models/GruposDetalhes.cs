using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickingByVoice.Models
{
    public class GruposDetalhes
    {
        [Key]
        public int GruposDetalhesId { get; set; }

        public int GrupoId { get; set; }

        public int UserId { get; set; }

        public virtual Grupos Grupos { get; set; }

        public virtual Usuario Estudante { get; set; }

        //public string GrupoEstudante { get { return string.Format("{0} / {1}", Grupos.Descricao, Estudante.FullName); } }

        //public virtual ICollection<Notas> Notas { get; set; }
    }
}