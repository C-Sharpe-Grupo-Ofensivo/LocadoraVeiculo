using FluentResults;
using LocadoraVeiculo.Dominio.Compartilhado;


namespace LocadoraVeiculo.Compartilhado {

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade registro)
        where TEntidade : EntidadeBase<TEntidade>;

}
