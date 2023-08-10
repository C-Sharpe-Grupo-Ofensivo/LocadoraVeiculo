using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Dominio.Compartilhado;

namespace LocadoraVeiculo.Infra.JSON.ModuloConfiguracaoPreco
{
    public class RepositorioConfigPrecoEmJson
    {
        protected ContextoDadosConfiguracaoPreco contextoDados;

        public RepositorioConfigPrecoEmJson(IContextoPersistencia contexto)
        {
            contextoDados = contexto as ContextoDadosConfiguracaoPreco;
        }

        public void Salvar(ConfiguracaoPreco registro)
        {
            var registros = ObterRegistros();
            var registroExistente = registros.FirstOrDefault(r => r.Id == registro.Id);

            if (registroExistente != null)
            {
                registroExistente.Atualizar(registro);
            }
            else
            {
                registros.Add(registroExistente);
            }

            contextoDados.GravarDados();
        }

        public List<ConfiguracaoPreco> ObterRegistros()
        {
            return contextoDados.ConfiguracaoPrecos;
        }


    }
}