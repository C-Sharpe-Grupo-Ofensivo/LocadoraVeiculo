using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado.Serializadores;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado
{
    [Serializable]
    public class GeradorTesteJsonContext : IContextoPersistencia
    {
        private readonly ISerializador serializador;

        public GeradorTesteJsonContext()
        {
            Funcionarios = new List<Funcionario>();

            //Materias = new List<Materia>();

            //Testes = new List<Teste>();

            //Questoes = new List<Questao>();
        }


        public GeradorTesteJsonContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        //public List<Materia> Materias { get; set; }

        public List<Funcionario> Funcionarios { get; set; }

        //public List<Teste> Testes { get; set; }

        //public List<Questao> Questoes { get; set; }

        public void DesfazerAlteracoes()
        {
            CarregarDados();
        }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Funcionarios.Any())
                this.Funcionarios.AddRange(ctx.Funcionarios);

            //    if (ctx.Materias.Any())
            //        this.Materias.AddRange(ctx.Materias);

            //    if (ctx.Questoes.Any())
            //        this.Questoes.AddRange(ctx.Questoes);

            //    if (ctx.Testes.Any())
            //        this.Testes.AddRange(ctx.Testes);
            //}
        }
    }
}
