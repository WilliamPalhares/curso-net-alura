using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola_Net_Domain.ModelDataAnottation
{
    public class TituloEleitorAttributeValidation : ValidationAttribute
    {
        private String TituloEleitoral { get; set; }

        private TituloEleitoralFormatter Formatter { get; set; }

        public TituloEleitorAttributeValidation() { this.Formatter = new TituloEleitoralFormatter(); }

        public TituloEleitorAttributeValidation(String CPF)
        {
            this.TituloEleitoral = CPF;
            this.Formatter = new TituloEleitoralFormatter();
        }

        public override bool IsValid(object value)
        {
            this.TituloEleitoral = this.Formatter.Unformat(value.ToString());
            return new TituloEleitoralValidator().IsValid(this.TituloEleitoral);
        }
    }
}
