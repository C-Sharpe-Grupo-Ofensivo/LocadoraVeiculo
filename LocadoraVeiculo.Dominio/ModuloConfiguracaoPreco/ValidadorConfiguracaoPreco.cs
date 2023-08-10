using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco
{
    public class ValidadorConfiguracaoPreco : AbstractValidator<ConfiguracaoPreco>, IValidadorConfiguracaoPreco
    {
        public ValidadorConfiguracaoPreco()
        {
            RuleFor(x => x.precoGasolina)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.precoGas)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.precoDiesel)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.precoAlcool)
                .NotEmpty()
                .NotNull();
        }
    }
}