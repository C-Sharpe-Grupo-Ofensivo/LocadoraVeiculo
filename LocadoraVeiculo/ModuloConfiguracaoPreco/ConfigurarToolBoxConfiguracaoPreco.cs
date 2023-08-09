using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloConfiguracaoPreco
{
    public class ConfigurarToolBoxConfiguracaoPreco : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Configuração de Preços";

        public override string TooltipInserir => throw new NotImplementedException();

        public override string TooltipEditar => throw new NotImplementedException();

        public override string TooltipExcluir => throw new NotImplementedException();

        public override string TooltipAdicionarItens => "Configurar Preço dos Combustas";
    }
}
