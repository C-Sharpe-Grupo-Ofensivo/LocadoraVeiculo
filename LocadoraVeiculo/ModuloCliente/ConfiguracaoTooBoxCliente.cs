using LocadoraVeiculo.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloCliente
{
    public class ConfiguracaoTooBoxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Cliente";

        public override string TooltipInserir => "Inserir nova Cliente";

        public override string TooltipEditar => "Editar uma Cliente existente";

        public override string TooltipExcluir => "Excluir uma Cliente existente";
    }
}
