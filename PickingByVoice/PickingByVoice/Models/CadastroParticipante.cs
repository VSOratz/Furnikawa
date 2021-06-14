using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class CadastroParticipante
    {
        [Key]
        public int Cadastro_ID { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public decimal CgcCPF { get; set; }

        [Display(Name = "Nome/Razão Social")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(250, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string NmRazaoSocial { get; set; }

        [Display(Name = "Sobrenome/NmFantasia")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string NmFantasia { get; set; }

        [Display(Name = "Flag Tipo Pessoa")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char FgTipoPessoa { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [StringLength(30, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "RG")]
        [StringLength(10, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string RegistroGeral { get; set; }

        [Display(Name = "ID CEP")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public int IdCEP { get; set; }

        [Display(Name = "Numero")]
        [StringLength(5, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string Complemento { get; set; }

        [Display(Name = "Numero Telefone")]
        [StringLength(15, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string NrTelefone { get; set; }

        [Display(Name = "Numero Celular")]
        [StringLength(16, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string NrCelular { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string Email { get; set; }

        [Display(Name = "Flag Ativo")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public char FgAtivo { get; set; }

        [Display(Name = "SgUser")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string SgUser { get; set; }

        [Display(Name = "Data Manutenção")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string DtManutencao { get; set; }

    }
}