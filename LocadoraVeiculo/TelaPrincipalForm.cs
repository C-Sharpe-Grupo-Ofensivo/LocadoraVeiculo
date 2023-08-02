namespace LocadoraVeiculo
{
    public partial class TelaPrincipalForm : Form
    {
        public TelaPrincipalForm()
        {
            InitializeComponent();
        }
        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }
        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void TelaPrincipalForm_Load(object sender, EventArgs e)
        {

        }
    }
}