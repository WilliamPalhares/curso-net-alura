using System;
using System.ComponentModel.DataAnnotations;

namespace Escola_Net.ViewModel
{
    public class TipoPessoaViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        public String Descricao { get; set; }
    }
}