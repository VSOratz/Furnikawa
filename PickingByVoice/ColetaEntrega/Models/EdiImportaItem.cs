using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Models
{
    public class EdiImportaItem
    {
        [Key]
        public int EdiImportaItemId { get; set; }

        public int EdiImportaMestreId { get; set; }

        [Display(Name = "Sequência Item")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public double SEQITEM { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string STATUS { get; set; }

        [Display(Name = "Número Romaneio")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string NRROMANEIO { get; set; }

        [Display(Name = "CPF do Motorista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(11, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 8)]
        [DataType(DataType.Text)]
        public string CPFMOTORISTA { get; set; }

        [Display(Name = "Nome do Motorista")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string NOMEMOTORISTA { get; set; }

        [Display(Name = "Placa do Veículo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(8, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string PLACA { get; set; }

        [Display(Name = "Número Nota")]
        [StringLength(10, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string NRNOTA { get; set; }

        [Display(Name = "Data Coleta")]
        [DataType(DataType.DateTime)]
        public DateTime DTCOLETA { get; set; }

        [Display(Name = "CNPJ Empresa")]
        [StringLength(14, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 12)]
        [DataType(DataType.Text)]
        public string CNPJEMPRESA { get; set; }

        [Display(Name = "Nome Empresa")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string NOMEEMPRESA { get; set; }

        [Display(Name = "Rua")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string RUA { get; set; }

        [Display(Name = "Número")]
        [StringLength(10, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres")]
        [DataType(DataType.Text)]
        public string NUMERO { get; set; }

        [Display(Name = "Complemento")]
        public string COMPLEMENTO { get; set; }

        [Display(Name = "Bairro")]
        public string BAIRRO { get; set; }

        [Display(Name = "Valor Nota")]
        public decimal VLNOTA { get; set; }

        [Display(Name = "Quantidade Nota")]
        [DataType(DataType.Currency)]
        public decimal QUANTIDADE { get; set; }

        [Display(Name = "Peso Nota")]
        [DataType(DataType.Currency)]
        public decimal PESO { get; set; }

        [Display(Name = "Tipo Entrega")]
        [StringLength(2, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [DataType(DataType.Text)]
        public string TPENTREGA { get; set; }

        [Display(Name = "Data Previsão")]
        [DataType(DataType.DateTime)]
        public DateTime DTPREVISAO { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(1, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string FGATIVO { get; set; }

        [Display(Name = "SgUser")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string SGUSER { get; set; }

        [Display(Name = "Data Manutenção")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public DateTime DTMANUTENCAO { get; set; }

        [ForeignKey("EdiImportaMestreId")]
        public virtual EdiImportaMestre EdiImportaMestre { get; set; }
    }
}