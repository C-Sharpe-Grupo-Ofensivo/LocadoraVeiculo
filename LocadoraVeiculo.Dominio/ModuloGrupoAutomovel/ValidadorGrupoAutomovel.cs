using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloGrupoAutomovel
{
    public class ValidadorGrupoAutomovel : AbstractValidator<GrupoAutomovel>, IValidadorGrupoAutomovel
    {

        public ValidadorGrupoAutomovel()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
