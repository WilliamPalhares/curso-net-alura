using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Escola_Net_Domain.Model
{
    [Table("TipoPessoa")]
    public class TipoPessoa : BaseModel
    {
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [MaxLength(40, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        [StringLength(40)]
        [Column("Descricao")]
        public String Descricao { get; set; }
    }
}
