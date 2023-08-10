using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco
{
    public class ConfiguracaoPreco : EntidadeBase<ConfiguracaoPreco>
    {
        public decimal precoGasolina { get; set; }
        public decimal precoGas { get; set; }
        public decimal precoDiesel { get; set; }
        public decimal precoAlcool { get; set; }

        public override void Atualizar(ConfiguracaoPreco registroAtualizado)
        {
            throw new NotImplementedException();
        }
    }
}
