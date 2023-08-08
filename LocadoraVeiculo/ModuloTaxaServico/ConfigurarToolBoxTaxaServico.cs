using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloTaxaServico
{
    public class ConfigurarToolBoxTaxaServico : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Taxa de Serviços";

        public override string TooltipInserir => "Inserir Taxa de Serviço";

        public override string TooltipEditar => "Editar Taxa de Serviço";

        public override string TooltipExcluir => "Excluir Taxa de Serviço";
    }
}
