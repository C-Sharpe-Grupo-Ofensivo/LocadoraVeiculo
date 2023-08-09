using LocadoraVeiculo.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloGrupoAutomovel
{
    public class ConfigurarToolBoxGrupoAutomovel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Grupo de Automóveis";

        public override string TooltipInserir => "Inserir Grupo de Automóvel";

        public override string TooltipEditar => "Editar um Grupo de Automóvel existente";

        public override string TooltipExcluir => "Excluir um Grupo de Automóvel existente";
    }
}
