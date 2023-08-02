using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado.Serializadores
{
    public interface ISerializador
    {
        GeradorTesteJsonContext CarregarDadosDoArquivo();

        void GravarDadosEmArquivo(GeradorTesteJsonContext dados);
    }
}
