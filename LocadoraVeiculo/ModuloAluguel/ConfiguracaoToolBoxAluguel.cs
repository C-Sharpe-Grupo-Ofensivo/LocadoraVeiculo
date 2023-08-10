using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloAluguel
{
    public class ConfiguracaoToolBoxAluguel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Aluguel";

        public override string TooltipInserir => "Inserir novo Aluguel";

        public override string TooltipEditar => "Editar uma Aluguel existente";

        public override string TooltipExcluir => "Excluir uma Aluguel existente";
    }
}
