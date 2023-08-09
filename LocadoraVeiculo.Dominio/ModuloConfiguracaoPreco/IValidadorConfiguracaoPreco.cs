using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco
{
    public interface IValidadorConfiguracaoPreco : IValidador<ConfiguracaoPreco>
    {
    }
}