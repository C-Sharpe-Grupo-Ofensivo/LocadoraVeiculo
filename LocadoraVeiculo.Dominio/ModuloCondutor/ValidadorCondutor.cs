using FluentValidation;
using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>, IValidadorCondutor
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Cliente)
                .NotNull()
                .NotEmpty().WithMessage("O campo Nome é obrigatório");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress().WithMessage("O campo Email é obrigatório");

            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\(\d{2}\) \d{4,5}-\d{4}$").WithMessage("O campo Telefone deve estar no formato (99) 99999-9999.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("O campo CPF deve estar no formato 999.999.999-99");

            RuleFor(x => x.Cnh)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$").WithMessage("o campo CNH deve estar no formato 99.999.999/9999-99");

            RuleFor(x => x.Validade)
                .NotEmpty()
                .NotNull();
        }
    }
}
