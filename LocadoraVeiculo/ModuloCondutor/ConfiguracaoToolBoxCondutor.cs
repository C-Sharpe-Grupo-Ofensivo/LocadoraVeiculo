using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloCondutor
{
    public class ConfiguracaoToolBoxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Condutores";

        public override string TooltipInserir => "Inserir Condutor";

        public override string TooltipEditar => "Editar Condutor";

        public override string TooltipExcluir => "Excluir Condutor";

        public override bool FiltrarHabilitado { get { return false; } }

        //public override bool PrecoHabilitado { get { return false; } }

        //public override bool DevolucaoHabilitado { get { return false; } }
    }
}
