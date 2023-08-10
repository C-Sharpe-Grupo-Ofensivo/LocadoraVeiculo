using LocadoraVeiculo.Dominio.Compartilhado;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco
{
    [Serializable]
    public class ConfiguracaoPreco : EntidadeBase<ConfiguracaoPreco>
    {
        public ConfiguracaoPreco()
        {
        }

        public ConfiguracaoPreco(decimal precoGasolina, decimal precoGas, decimal precoDiesel, decimal precoAlcool)
        {
            this.precoGasolina = precoGasolina;
            this.precoGas = precoGas;
            this.precoDiesel = precoDiesel;
            this.precoAlcool = precoAlcool;
        }

        public decimal precoGasolina { get; set; }
        public decimal precoGas { get; set; }
        public decimal precoDiesel { get; set; }
        public decimal precoAlcool { get; set; }

        public override void Atualizar(ConfiguracaoPreco registroAtualizado)
        {
            precoGasolina = registroAtualizado.precoGasolina;
            precoGas = registroAtualizado.precoGas;
            precoDiesel = registroAtualizado.precoDiesel;
            precoAlcool = registroAtualizado.precoAlcool;
        }
    }
}
