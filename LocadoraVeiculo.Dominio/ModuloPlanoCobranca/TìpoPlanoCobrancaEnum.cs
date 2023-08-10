using System.ComponentModel;

namespace LocadoraVeiculo.Dominio.ModuloPlanoCobranca
{
    public enum TìpoPlanoCobrancaEnum
    {
        [Description(" ")]
        Nenhum,

        [Description("Plano Diário")]
        PlanoDiario,

        [Description("Plano Controlador")]
        PlanoControlador,

        [Description("Plano Livre")]
        PlanoLivre
    }
}