using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Infra.JSON.Serializadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.JSON.ModuloConfiguracaoPreco
{
    [Serializable]
    public class ContextoDadosConfiguracaoPreco : IContextoPersistencia
    {
        public List<ConfiguracaoPreco> ConfiguracaoPrecos { get; set; }
        private readonly SerializadorDadosEmJson serializador;
        public ContextoDadosConfiguracaoPreco()
        {
            ConfiguracaoPrecos = new List<ConfiguracaoPreco>();
        }
        public ContextoDadosConfiguracaoPreco(SerializadorDadosEmJson serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public void DesfazerAlteracoes()
        {
            CarregarDados();
        }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.ConfiguracaoPrecos.Any())
                this.ConfiguracaoPrecos.AddRange(ctx.ConfiguracaoPrecos);
        }
    }
}
