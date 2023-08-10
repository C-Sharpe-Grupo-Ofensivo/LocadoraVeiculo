using FluentValidation.TestHelper;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloPlanoCobranca
{
    [TestClass]
    public class ValidadorCobrancaTest
    {
        private GrupoAutomovel grupoAutomovel;
        private PlanoCobranca planoCobranca;
        private ValidadorPlanoCobranca planoValidador;

        public ValidadorCobrancaTest()
        {
            grupoAutomovel = new GrupoAutomovel();
            planoCobranca = new PlanoCobranca();
            planoValidador = new ValidadorPlanoCobranca();
        }

        [TestMethod]
        public void PrecoDiaria_deve_ser_obrigatorio_e_conter_apenas_numeros_validos()
        {
            planoCobranca.PrecoDiaria = 100;

            var resultado = planoValidador.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoDiaria);
        }

        [TestMethod]
        public void TipoPlano_deve_ser_obrigatorio_e_diferente_de_Nenhum()
        {
            planoCobranca.PlanoDiario = TìpoPlanoCobrancaEnum.PlanoDiario;

            var resultado = planoValidador.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.TipoPlano);
        }

        [TestMethod]
        public void GrupoAutomoveis_deve_ser_obrigatorio()
        {
            planoCobranca.GrupoAutomovel = grupoAutomovel;

            var resultado = planoValidador.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.GrupoAutomovel);
        }

        [TestMethod]
        public void PrecoPorKm_deve_ser_obrigatorio_para_tipos_de_plano_PlanoDiario_e_PlanoControlador()
        {
            planoCobranca.TipoPlano = TipoPlano;
            planoCobranca.PrecoPorKm = 32;

            var resultado = planoValidador.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoPorKm);
        }

        [TestMethod]
        public void PrecoPorKm_nao_deve_ser_aplicavel_para_tipo_de_plano_Livre()
        {
            planoCobranca.TipoPlano = TipoPlanoEnum.PlanoLivre;
            planoCobranca.PrecoPorKm = null;

            var resultado = planoValidador.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoPorKm);
        }
    }
}
