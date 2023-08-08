namespace LocadoraVeiculo
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menu = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            veiculoMenuItem = new ToolStripMenuItem();
            funcionarioMenuItem = new ToolStripMenuItem();
            condutorMenuItem = new ToolStripMenuItem();
            parceiroMenuItem = new ToolStripMenuItem();
            cupomMenuItem = new ToolStripMenuItem();
            taxaDeServicoMenuItem = new ToolStripMenuItem();
            planoDeCobrancaMenuItem = new ToolStripMenuItem();
            grupoDeVeiculoMenuItem = new ToolStripMenuItem();
            clienteMenuItem = new ToolStripMenuItem();
            precoCombustivelMenuItem = new ToolStripMenuItem();
            locacaoMenuItem = new ToolStripMenuItem();
            panelRegistros = new Panel();
            statusStrip1 = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            toolbox = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnVisualizar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnGerarPdf = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnFiltrar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            labelTipoCadastro = new ToolStripLabel();
            menu.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolbox.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { veiculoMenuItem, funcionarioMenuItem, condutorMenuItem, parceiroMenuItem, cupomMenuItem, taxaDeServicoMenuItem, planoDeCobrancaMenuItem, grupoDeVeiculoMenuItem, clienteMenuItem, precoCombustivelMenuItem, locacaoMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // veiculoMenuItem
            // 
            veiculoMenuItem.Name = "veiculoMenuItem";
            veiculoMenuItem.Size = new Size(180, 22);
            veiculoMenuItem.Text = "Veículo";
            veiculoMenuItem.Click += veiculoMenuItem_Click;
            // 
            // funcionarioMenuItem
            // 
            funcionarioMenuItem.Name = "funcionarioMenuItem";
            funcionarioMenuItem.Size = new Size(180, 22);
            funcionarioMenuItem.Text = "Funcionário";
            funcionarioMenuItem.Click += funcionarioMenuItem_Click;
            // 
            // condutorMenuItem
            // 
            condutorMenuItem.Name = "condutorMenuItem";
            condutorMenuItem.Size = new Size(180, 22);
            condutorMenuItem.Text = "Condutor";
            // 
            // parceiroMenuItem
            // 
            parceiroMenuItem.Name = "parceiroMenuItem";
            parceiroMenuItem.Size = new Size(180, 22);
            parceiroMenuItem.Text = "Parceiro";
            parceiroMenuItem.Click += parceiroMenuItem_Click;
            // 
            // cupomMenuItem
            // 
            cupomMenuItem.Name = "cupomMenuItem";
            cupomMenuItem.Size = new Size(180, 22);
            cupomMenuItem.Text = "Cupom";
            // 
            // taxaDeServicoMenuItem
            // 
            taxaDeServicoMenuItem.Name = "taxaDeServicoMenuItem";
            taxaDeServicoMenuItem.Size = new Size(180, 22);
            taxaDeServicoMenuItem.Text = "Taxa de Serviço";
            // 
            // planoDeCobrancaMenuItem
            // 
            planoDeCobrancaMenuItem.Name = "planoDeCobrancaMenuItem";
            planoDeCobrancaMenuItem.Size = new Size(180, 22);
            planoDeCobrancaMenuItem.Text = "Plano de Cobrança";
            // 
            // grupoDeVeiculoMenuItem
            // 
            grupoDeVeiculoMenuItem.Name = "grupoDeVeiculoMenuItem";
            grupoDeVeiculoMenuItem.Size = new Size(180, 22);
            grupoDeVeiculoMenuItem.Text = "Grupo de Veículo";
            grupoDeVeiculoMenuItem.Click += grupoDeVeiculoMenuItem_Click;
            // 
            // clienteMenuItem
            // 
            clienteMenuItem.Name = "clienteMenuItem";
            clienteMenuItem.Size = new Size(180, 22);
            clienteMenuItem.Text = "Cliente";
            clienteMenuItem.Click += clienteMenuItem_Click;
            // 
            // precoCombustivelMenuItem
            // 
            precoCombustivelMenuItem.Name = "precoCombustivelMenuItem";
            precoCombustivelMenuItem.Size = new Size(180, 22);
            precoCombustivelMenuItem.Text = "Preço Combustível";
            // 
            // locacaoMenuItem
            // 
            locacaoMenuItem.Name = "locacaoMenuItem";
            locacaoMenuItem.Size = new Size(180, 22);
            locacaoMenuItem.Text = "Locação";
            // 
            // panelRegistros
            // 
            panelRegistros.Location = new Point(0, 52);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(800, 377);
            panelRegistros.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(52, 17);
            labelRodape.Text = "[rodapé]";
            // 
            // toolbox
            // 
            toolbox.Enabled = false;
            toolbox.ImageScalingSize = new Size(20, 20);
            toolbox.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator2, btnVisualizar, toolStripSeparator3, btnGerarPdf, toolStripSeparator1, btnFiltrar, toolStripSeparator4, labelTipoCadastro });
            toolbox.Location = new Point(0, 24);
            toolbox.Name = "toolbox";
            toolbox.Size = new Size(800, 32);
            toolbox.TabIndex = 4;
            toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnInserir.ImageScaling = ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(5);
            btnInserir.Size = new Size(72, 29);
            btnInserir.Text = "Adicionar";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(5);
            btnEditar.Size = new Size(51, 29);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(5);
            btnExcluir.Size = new Size(56, 29);
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 32);
            // 
            // btnVisualizar
            // 
            btnVisualizar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnVisualizar.ImageScaling = ToolStripItemImageScaling.None;
            btnVisualizar.ImageTransparentColor = Color.Magenta;
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Padding = new Padding(5);
            btnVisualizar.Size = new Size(70, 29);
            btnVisualizar.Text = "Visualizar";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 32);
            // 
            // btnGerarPdf
            // 
            btnGerarPdf.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnGerarPdf.ImageScaling = ToolStripItemImageScaling.None;
            btnGerarPdf.ImageTransparentColor = Color.Magenta;
            btnGerarPdf.Name = "btnGerarPdf";
            btnGerarPdf.Padding = new Padding(5);
            btnGerarPdf.Size = new Size(70, 29);
            btnGerarPdf.Text = "Gerar Pdf";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 32);
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new Padding(5);
            btnFiltrar.Size = new Size(51, 29);
            btnFiltrar.Text = "Filtrar";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 32);
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(90, 29);
            labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolbox);
            Controls.Add(statusStrip1);
            Controls.Add(panelRegistros);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "TelaPrincipalForm";
            Text = "Locadora Veiculo";
            menu.ResumeLayout(false);
            menu.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolbox.ResumeLayout(false);
            toolbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private Panel panelRegistros;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelRodape;
        private ToolStripMenuItem veiculoMenuItem;
        private ToolStripMenuItem funcionarioMenuItem;
        private ToolStripMenuItem condutorMenuItem;
        private ToolStripMenuItem parceiroMenuItem;
        private ToolStripMenuItem cupomMenuItem;
        private ToolStripMenuItem taxaDeServicoMenuItem;
        private ToolStripMenuItem planoDeCobrancaMenuItem;
        private ToolStripMenuItem grupoDeVeiculoMenuItem;
        private ToolStripMenuItem clienteMenuItem;
        private ToolStripMenuItem precoCombustivelMenuItem;
        private ToolStripMenuItem locacaoMenuItem;
        private ToolStrip toolbox;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnVisualizar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnGerarPdf;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnFiltrar;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel labelTipoCadastro;
    }
}