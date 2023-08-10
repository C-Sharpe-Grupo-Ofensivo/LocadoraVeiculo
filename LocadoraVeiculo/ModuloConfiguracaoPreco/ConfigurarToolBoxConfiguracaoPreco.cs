using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloConfiguracaoPreco
{
    public class ConfigurarToolBoxConfiguracaoPreco : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Preço";

        public override string TooltipInserir => "Inserir novo Preço";

        public override string TooltipEditar => "Editar um Preço";

        public override string TooltipExcluir => "Excluir um Preço existente";
    }
}
