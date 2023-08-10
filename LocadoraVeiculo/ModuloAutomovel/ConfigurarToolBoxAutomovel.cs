using LocadoraVeiculo.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloAutomovel
{
    public class ConfigurarToolBoxAutomovel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Automóveis";

        public override string TooltipInserir => "Inserir Automóvel";

        public override string TooltipEditar => "Editar Automóvel existente";

        public override string TooltipExcluir => "Excluir Automóvel existente";
        public override bool FiltrarHabilitado => true;
    }
}
