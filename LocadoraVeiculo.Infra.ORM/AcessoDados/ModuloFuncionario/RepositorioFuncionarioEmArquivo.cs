using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmArquivo :
        RepositorioEmArquivoBase<Funcionario>,IRepositorioFuncionario
    {
        protected GeradorTesteJsonContext contextoDados;
        public RepositorioFuncionarioEmArquivo(IContextoPersistencia contexto)
        {
            contextoDados = contexto as GeradorTesteJsonContext;
        }

        public void Editar(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Funcionario novoRegistro)
        {
            throw new NotImplementedException();
        }
        public override List<Funcionario> ObterRegistros()
        {
            return contextoDados.Funcionarios;
        }
        public Funcionario SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarPorNome(string nome)
        {
            return ObterRegistros().FirstOrDefault(x => x.Nome == nome);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return ObterRegistros();
        }
    }
}
