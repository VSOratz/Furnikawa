using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickingByVoice.Models
{
    public class Notas
    {
        [Key]
        public int NotaId { get; set; }

        public int GruposDetalhesId { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [Range(0, 1, ErrorMessage = "O Campo {0} tem que está {1} e {2}")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float Percentual { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [Range(0, 5, ErrorMessage = "O Campo {0} contém valores entre {1} e {2}")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public float Nota { get; set; }

        public virtual GruposDetalhes GruposDetalhes { get; set; }
    }
}