using FluentResults;
using LocadoraVeiculo.Dominio.ModuloAluguel;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Aplicacao.ModuloAluguel
{
    public class ServicoAluguel
    {
        private IRepositorioAluguel repositorioAluguel;
        private IValidadorAluguel validadorAluguel;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
        }

        public Result Inserir(Aluguel aluguel)
        {
            Log.Debug("Tentando inserir aluguek...{@d}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioAluguel.Inserir(aluguel);

                Log.Debug("aluguel {aluguelId} inserida com sucesso", aluguel.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir aluguel.";

                Log.Error(exc, msgErro + "{@d}", aluguel);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Aluguel aluguel)
        {
            Log.Debug("Tentando editar aluguel...{@d}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAluguel.Editar(aluguel);

                Log.Debug("aluguel {aluguelId} editada com sucesso", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar aluguel.";

                Log.Error(exc, msgErro + "{@d}", aluguel);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel aluguel)
        {
            Log.Debug("Tentando excluir aluguel...{@d}", aluguel);

            try
            {
                bool configuraAluguelExiste = repositorioAluguel.Existe(aluguel);

                if (configuraAluguelExiste == false)
                {
                    Log.Warning("Aluguel {aluguelId} não encontrada para excluir", aluguel.Id);

                    return Result.Fail("aluguel não encontrada");
                }

                repositorioAluguel.Excluir(aluguel);

                Log.Debug("aluguel {aluguelId} excluido com sucesso", aluguel.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;


                msgErro = "Falha ao tentar excluir aluguel";



                Log.Error(ex, msgErro + " {aluguelId}", aluguel.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarAluguel(Aluguel aluguel)
        {
            var resultadoValidacao = validadorAluguel.Validate(aluguel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));



            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
    }
}
