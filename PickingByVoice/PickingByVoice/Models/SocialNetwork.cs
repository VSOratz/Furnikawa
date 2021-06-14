﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class SocialNetwork
    {
        [Key]
        public int SocialNetwork_ID { get; set; }

        [Display(Name = "Rede Social")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(250, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string DescriptionSN { get; set; }


        [Display(Name = "NomeParticipante")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string Nmparticipant { get; set; }

        [Display(Name = "Link Rede")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string LinkSocial { get; set; }

        [Display(Name = "Flag Ativo")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char FgActive { get; set; }

        [Display(Name = "APP_ID")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string APP_ID { get; set; }

        [Display(Name = "REST_API_KEY")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string REST_API_KEY { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string UserID { get; set; }

        [Display(Name = "Data Modificação")]
        [DataType(DataType.DateTime)]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string DhModification { get; set; }
        //[Display(Name = "tes")]
        //public virtual NotificationSocialNetwork notificationSocialNetwork { get; set; }
    }
}