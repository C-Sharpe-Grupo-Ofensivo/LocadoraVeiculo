using LocadoraVeiculo.Infra.JSON.ModuloConfiguracaoPreco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.JSON.Serializadores
{
    public class SerializadorDadosEmJson
    {
        private const string arquivo = @"ConfiguracaoPreco.Json";

        public ContextoDadosConfiguracaoPreco CarregarDadosDoArquivo()
        {
            if (File.Exists(arquivo) == false)
                return new ContextoDadosConfiguracaoPreco();

            string json = File.ReadAllText(arquivo);

            return JsonSerializer.Deserialize<ContextoDadosConfiguracaoPreco>(json);
        }

        public void GravarDadosEmArquivo(ContextoDadosConfiguracaoPreco dados)
        {
            var config = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(dados, config);

            File.WriteAllText(arquivo, json);
        }
    }
}
