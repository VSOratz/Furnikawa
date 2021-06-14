using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class NotificationSocialNetworks
    {
        [Key]
        public int NotificationSocialNetwork_ID { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(250, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Index("DescriptionSNIndex", IsUnique = true)]
        public string DescriptionSN { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string TiteSN { get; set; }

        [Display(Name = "Link Rede")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string LinkSocial { get; set; }

        [Display(Name = "Flag Ativo")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char FgActive { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string UserID { get; set; }

        [Display(Name = "Data Modificação")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string DhModification { get; set; }


        //public int socialNetworkId { get; set; }
        //[ForeignKey("socialNetworkId")]
        //public virtual SocialNetwork socialNetwork { get; set; }
    }
}