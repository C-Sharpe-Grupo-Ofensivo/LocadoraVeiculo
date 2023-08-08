using FluentValidation;
using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel>, IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.Placa).NotEmpty().NotNull().NaoPodeCaracteresEspeciais().WithMessage("A placa deve estar em um formato válido.");
            RuleFor(x => x.Cor).NotEmpty().NotNull();
            RuleFor(x => x.Marca).NotEmpty().NotNull();
            RuleFor(x => x.Modelo).NotEmpty().NotNull();
            RuleFor(x => x.CapacidadeLitros).Must(x => x > 0);
            RuleFor(x => x.Quilometragem).Must(x => x > 0);
            RuleFor(x => x.TipoCombustivel).Must(x => x > 0);

            RuleFor(x => x.Ano).Must(x => x > 1886 && x <= DateTime.Now.Year).WithMessage("Nenhum carro foi criado antes de 1886 e nem depois desse ano espertinho.");
            RuleFor(x => x.Foto).Must(x => x == null || x.Length <= 2697000).WithMessage("O tamanho da foto deve ser menor ou igual a 2 megabytes.");
        }
    }
}
