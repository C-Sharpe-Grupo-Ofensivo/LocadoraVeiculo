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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipalForm));
            menuStrip1 = new MenuStrip();
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
            toolbox = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnVisualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnGerarPDF = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnFiltrar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            labelTipoCadastro = new ToolStripLabel();
            panelRegistros = new Panel();
            statusStrip1 = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            toolbox.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
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
            // 
            // clienteMenuItem
            // 
            clienteMenuItem.Name = "clienteMenuItem";
            clienteMenuItem.Size = new Size(180, 22);
            clienteMenuItem.Text = "Cliente";
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
            // toolbox
            // 
            toolbox.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator1, btnVisualizar, toolStripSeparator2, btnGerarPDF, toolStripSeparator3, btnFiltrar, toolStripSeparator4, labelTipoCadastro });
            toolbox.Location = new Point(0, 24);
            toolbox.Name = "toolbox";
            toolbox.Size = new Size(800, 25);
            toolbox.TabIndex = 1;
            toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnInserir.Image = (Image)resources.GetObject("btnInserir.Image");
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(62, 22);
            btnInserir.Text = "Adicionar";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(41, 22);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnExcluir.Image = (Image)resources.GetObject("btnExcluir.Image");
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(46, 22);
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnVisualizar
            // 
            btnVisualizar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnVisualizar.Image = (Image)resources.GetObject("btnVisualizar.Image");
            btnVisualizar.ImageTransparentColor = Color.Magenta;
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Size = new Size(60, 22);
            btnVisualizar.Text = "Visualizar";
            btnVisualizar.Click += btnVisualizar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // btnGerarPDF
            // 
            btnGerarPDF.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnGerarPDF.Image = (Image)resources.GetObject("btnGerarPDF.Image");
            btnGerarPDF.ImageTransparentColor = Color.Magenta;
            btnGerarPDF.Name = "btnGerarPDF";
            btnGerarPDF.Size = new Size(63, 22);
            btnGerarPDF.Text = "Gerar PDF";
            btnGerarPDF.Click += btnGerarPdf_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnFiltrar.Image = (Image)resources.GetObject("btnFiltrar.Image");
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(41, 22);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(90, 22);
            labelTipoCadastro.Text = "[tipoCadastro]";
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
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(panelRegistros);
            Controls.Add(toolbox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipalForm";
            Text = "Locadora Veiculo";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolbox.ResumeLayout(false);
            toolbox.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStrip toolbox;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnVisualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnGerarPDF;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnFiltrar;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel labelTipoCadastro;
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
    }
}