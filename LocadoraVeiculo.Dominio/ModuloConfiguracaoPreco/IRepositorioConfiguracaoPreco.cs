using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco
{
    public interface IRepositorioConfiguracaoPreco : IRepositorio<ConfiguracaoPreco>
    {
        void GravarConfiguracaoPrecoEmArquivoJson(ConfiguracaoPreco configuracaoPreco);
        
        List<ConfiguracaoPreco> SelecionarTodos();
    }
}