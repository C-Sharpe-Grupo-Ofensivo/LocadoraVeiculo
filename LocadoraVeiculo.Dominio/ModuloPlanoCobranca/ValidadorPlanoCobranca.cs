using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.GrupoAutomovel)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoDiaria)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.TipoPlano)
                .NotEmpty()
                .NotNull();

        }
    }
}
