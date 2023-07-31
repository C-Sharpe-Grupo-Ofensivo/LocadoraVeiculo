using FluentResults;
using LocadoraVeiculo.Dominio.Compartilhado;


namespace LocadoraDeVeiculos.WinApp.Compartilhado {

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade registro)
        where TEntidade : EntidadeBase<TEntidade>;

}
