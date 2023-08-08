using LocadoraVeiculo.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloParceiro
{
    public class ConfigurarToolBoxParceiro : ConfiguracaoToolboxBase

    {
    public override string TipoCadastro => "Cadastro de Parceiro";

    public override string TooltipInserir => "Inserir novo Parceiro";

    public override string TooltipEditar => "Editar um Parceiro existente";

    public override string TooltipExcluir => "Excluir um Parceiro existente";


    }
}
