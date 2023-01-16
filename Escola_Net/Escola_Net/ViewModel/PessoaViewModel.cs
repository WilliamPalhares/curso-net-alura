using Escola_Net_Domain.Model;
using Escola_Net_Domain.ModelDataAnottation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Escola_Net.ViewModel
{
    public class PessoaViewModel : BaseViewModel
    {
        public PessoaViewModel() {  }

        public PessoaViewModel(Pessoa pessoa)
        {
            this.Nome = pessoa.Nome;   
            this.NomeMae = pessoa.NomeMae;
            this.NomePai = pessoa.NomePai;
            this.CPF = pessoa.CPF;
            this.Identidade = pessoa.Identidade;
            this.OrgaoExpeditor = pessoa.OrgaoExpeditor;
            this.TituloEleitor = pessoa.TituloEleitor;
            this.Endereco = pessoa.Endereco;
            this.Email = pessoa.Email;
            this.Id = pessoa.Id;
            this.IdTipoPessoa = pessoa.IdTipoPessoa;
        }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo Nome do Pai é obrigatório")]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        public String NomePai { get; set; }

        [Required(ErrorMessage = "O campo Nome da Mãe é obrigatório")]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        public String NomeMae { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "Valor do campo é superior a 11 caracteres")]
        [CPFAttributeValidation(ErrorMessage = "CPF Inválido")]
        public String CPF { get; set; }

        [Required(ErrorMessage = "O campo Identidade é obrigatório")]
        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        public String Identidade { get; set; }

        [Required(ErrorMessage = "O campo Orgão Expeditor é obrigatório")]
        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        public String OrgaoExpeditor { get; set; }

        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        [TituloEleitorAttributeValidation(ErrorMessage = "Titulo Eleitor inválido")]
        public String TituloEleitor { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório")]
        [MaxLength(1000, ErrorMessage = "Valor do campo é superior a 1000 caracteres")]
        public String Endereco { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [MaxLength(10, ErrorMessage = "Valor do campo é superior a 10 caracteres")]
        public String CEP { get; set; }

        [EmailAddress]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        public String Email { get; set; }

        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "Valor do Tipo da Pessoa é obrigatório")]
        public Int64 IdTipoPessoa { get; set; }

        public virtual TipoPessoaViewModel TipoPessoaViewModel { get; set; }
    }
}
