using Escola_Net_Domain.ModelDataAnottation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola_Net_Domain.Model
{
    [Table("Pessoa")]
    public class Pessoa : BaseModel
    {
        public Pessoa() {  }

        public Pessoa(String Nome, String NomePai, String NomeMae, String CPF, String Identidade,
                      String OrgaoExpeditor, String TituloEleitor, String Endereco, String CEP,
                      Int64 IdTipoPessoa) 
        { 
            this.Nome = Nome;
            this.NomePai = NomePai;
            this.NomeMae = NomeMae;
            this.CPF = CPF;
            this.Identidade = Identidade;
            this.OrgaoExpeditor = OrgaoExpeditor;
            this.TituloEleitor = TituloEleitor;
            this.Endereco = Endereco;  
            this.CEP = CEP;
            this.IdTipoPessoa = IdTipoPessoa;
        }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        [StringLength(255)]
        [Column("Nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo Nome do Pai é obrigatório")]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        [StringLength(255)]
        [Column("NomePai")]
        public String NomePai { get; set; }

        [Required(ErrorMessage = "O campo Nome da Mãe é obrigatório")]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        [StringLength(255)]
        [Column("NomeMae")]
        public String NomeMae { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "Valor do campo é superior a 11 caracteres")]
        [StringLength(11)]
        [Column("CPF")]
        [CPFAttributeValidation(ErrorMessage = "CPF Inválido")]
        public String CPF { get; set; }

        [Required(ErrorMessage = "O campo Identidade é obrigatório")]
        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        [StringLength(40)]
        [Column("Identidade")]
        public String Identidade { get; set; }

        [Required(ErrorMessage = "O campo Orgão Expeditor é obrigatório")]
        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        [StringLength(40)]
        [Column("OrgaoExpeditor")]
        public String OrgaoExpeditor { get; set; }

        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        [StringLength(40)]
        [Column("TituloEleitor")]
        [TituloEleitorAttributeValidation(ErrorMessage = "Titulo Eleitor inválido")]
        public String TituloEleitor { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório")]
        [MaxLength(1000, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        [StringLength(1000)]
        [Column("Endereco")]
        public String Endereco { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [MaxLength(10, ErrorMessage = "Valor do campo é superior a 10 caracteres")]
        [StringLength(10)]
        [Column("CEP")]
        public String CEP { get; set; }

        [EmailAddress]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        [StringLength(255)]
        [Column("Email")]
        public String Email { get; set; }

        [Column("DataCriacao")]
        [Required]
        public DateTime DataCriacao { get; set; }

        [Column("IdTipoPessoa")]
        public Int64 IdTipoPessoa { get; set; }

        [Required]
        public virtual TipoPessoa TipoPessoa { get; set; }
    }
}
