using FluentValidation;
using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(14);

            RuleFor(x => x.Estado)
                .NotEmpty()
                .NotNull()
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .NotNull()
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .NotNull()
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Rua)
                .NotEmpty()
                .NotNull()
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.NumeroCasa)
                .NotEmpty()
                .NotNull();

            When(x => x.TipoCliente == TipoClienteEnum.CNPJ, () =>
            {
                RuleFor(x => x.Cnpj)
                    
                    .NotNull();


                RuleFor(x => x.Cpf)
                    .Empty();

                
                   
            });

            When(x => x.TipoCliente == TipoClienteEnum.CPF, () =>
            {
                RuleFor(x => x.Cpf)
                  
                    .NotNull();


                RuleFor(x => x.Cnpj)
                    .Empty();
                   
            });

        }
    }
}
