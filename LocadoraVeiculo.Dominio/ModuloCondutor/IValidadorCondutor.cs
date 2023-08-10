using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloCondutor
{
    public interface IValidadorCondutor : IValidator<Condutor>
    {
    }
}
