using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        //RuleFor(x => x.Condutor)
        //        .NotNull().NotEmpty();

        public ValidadorAluguel()
        {
            //RuleFor(x => x.Condutor)
            //    .NotNull().NotEmpty();

            RuleFor(x => x.GrupoAutomovel)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PlanoCobranca)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Automovel)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataLocacao)
                .NotNull()
                .NotEmpty()
                .Must(x => x >= DateTime.UtcNow);

            RuleFor(x => x.DevolucaoPrevista)
                .NotNull()
                .NotEmpty()
                .Must(x => x > DateTime.UtcNow);
        }
    }
}
