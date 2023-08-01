using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado
{
    public abstract class RepositorioEmArquivoBase<T> where T : EntidadeBase<T>
    {
        public abstract List<T> ObterRegistros();

        public virtual void Inserir(T novoRegistro)
        {
            var registros = ObterRegistros();

            registros.Add(novoRegistro);
        }

        public virtual void Editar(T registro)
        {
            var registros = ObterRegistros();

            foreach (var item in registros)
            {
                if (item.Id == registro.Id)
                {
                    item.Atualizar(registro);
                    break;
                }
            }
        }

        public virtual void Excluir(T registro)
        {
            var registros = ObterRegistros();

            registros.Remove(registro);
        }

        public virtual List<T> SelecionarTodos()
        {
            return ObterRegistros().ToList();
        }

        public virtual T SelecionarPorId(int id)
        {
            return ObterRegistros()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
