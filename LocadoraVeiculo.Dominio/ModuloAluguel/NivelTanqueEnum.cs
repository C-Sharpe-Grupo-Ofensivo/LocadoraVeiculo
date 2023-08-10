using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloAluguel
{
    public enum NivelTanqueEnum
    {
        [Description("Vazio")]
        Vazio,

        [Description("1/4")]
        UmQuarto,

        [Description("1/2")]
        MeioTanque,

        [Description("3/4")]
        TresQuartos,

        [Description("Cheio")]
        Cheio
    }
}
