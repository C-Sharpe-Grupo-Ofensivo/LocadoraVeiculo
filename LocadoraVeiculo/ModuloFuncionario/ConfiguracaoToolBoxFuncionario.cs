using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloFuncionario
{
    public class ConfiguracaoToolBoxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionário";

        public override string TooltipInserir => "Inserir novo Funcionário";

        public override string TooltipEditar => "Editar um Funcionário existente";

        public override string TooltipExcluir => "Excluir um Funcionário existente";
    }
}
