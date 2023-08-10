using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloPlanoCobranca
{
    internal class ConfiguraToolBoxPlanoCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Plano de Cobrança";

        public override string TooltipInserir => "Inserir Plano de Cobrança";

        public override string TooltipEditar => "Editar Plano de Cobrança";

        public override string TooltipExcluir => "Excluir Plano de Cobrança";

    
    }
}
