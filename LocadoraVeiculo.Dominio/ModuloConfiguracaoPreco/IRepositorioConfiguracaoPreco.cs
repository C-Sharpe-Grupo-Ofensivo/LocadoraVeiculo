using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco
{
    public interface IRepositorioConfiguracaoPreco
    {
        void GravarConfiguracaoPrecoEmArquivoJson(ConfiguracaoPreco configuracaoPreco);
        ConfiguracaoPreco ObterConfiguracaoPreco();
    }
}