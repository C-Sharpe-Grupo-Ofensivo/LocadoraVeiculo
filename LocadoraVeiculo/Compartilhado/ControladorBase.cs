

namespace LocadoraVeiculo.Compartilhado {
    public abstract class ControladorBase {
        protected string mensagemRodape;

        public abstract void Inserir();

        public virtual void Editar() { }

        public abstract void Excluir();

        public virtual void Duplicar() { }

        public virtual void Filtrar() { }

        public virtual void GerarPdf() { }

        public virtual void Visualizar() { }

        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();

        public string ObterMensagemRodape() {
            return mensagemRodape;
        }
    }
}
