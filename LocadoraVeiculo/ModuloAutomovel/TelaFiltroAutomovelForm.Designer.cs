namespace LocadoraVeiculo.ModuloAutomovel
{
    partial class TelaFiltroAutomovelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtListaGrupoAutomoveis = new ComboBox();
            label6 = new Label();
            bntCancelar = new Button();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // txtListaGrupoAutomoveis
            // 
            txtListaGrupoAutomoveis.FormattingEnabled = true;
            txtListaGrupoAutomoveis.Location = new Point(208, 41);
            txtListaGrupoAutomoveis.Name = "txtListaGrupoAutomoveis";
            txtListaGrupoAutomoveis.Size = new Size(427, 23);
            txtListaGrupoAutomoveis.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 44);
            label6.Name = "label6";
            label6.Size = new Size(174, 15);
            label6.TabIndex = 28;
            label6.Text = "Escolha o Grupo de Automovel:";
            // 
            // bntCancelar
            // 
            bntCancelar.DialogResult = DialogResult.Cancel;
            bntCancelar.Location = new Point(560, 123);
            bntCancelar.Name = "bntCancelar";
            bntCancelar.Size = new Size(75, 53);
            bntCancelar.TabIndex = 31;
            bntCancelar.Text = " Cancelar";
            bntCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(463, 123);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 53);
            btnGravar.TabIndex = 30;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaFiltroAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 200);
            Controls.Add(bntCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtListaGrupoAutomoveis);
            Controls.Add(label6);
            Name = "TelaFiltroAutomovelForm";
            Text = "TelaFiltroAutomovelForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox txtListaGrupoAutomoveis;
        private Label label6;
        private Button bntCancelar;
        private Button btnGravar;
    }
}