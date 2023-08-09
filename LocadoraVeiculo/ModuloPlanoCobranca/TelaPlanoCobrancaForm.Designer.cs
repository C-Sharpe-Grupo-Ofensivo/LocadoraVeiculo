namespace LocadoraVeiculo.ModuloPlanoCobranca
{
    partial class TelaPlanoCobrancaForm
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
            cmbGrupoAutomovel = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbTipoPlano = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtPlanoDiario = new NumericUpDown();
            txtPrecoKm = new NumericUpDown();
            txtKmDisponivel = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)txtPlanoDiario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKmDisponivel).BeginInit();
            SuspendLayout();
            // 
            // cmbGrupoAutomovel
            // 
            cmbGrupoAutomovel.FormattingEnabled = true;
            cmbGrupoAutomovel.Location = new Point(118, 12);
            cmbGrupoAutomovel.Name = "cmbGrupoAutomovel";
            cmbGrupoAutomovel.Size = new Size(121, 23);
            cmbGrupoAutomovel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 1;
            label1.Text = "Grupo Automovel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo Plano";
            label2.Click += label2_Click;
            // 
            // cmbTipoPlano
            // 
            cmbTipoPlano.FormattingEnabled = true;
            cmbTipoPlano.Location = new Point(118, 85);
            cmbTipoPlano.Name = "cmbTipoPlano";
            cmbTipoPlano.Size = new Size(121, 23);
            cmbTipoPlano.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 128);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 4;
            label3.Text = "Plano Diario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 164);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 5;
            label4.Text = "Preço Km";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 206);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 6;
            label5.Text = "Km Disponivel";
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(118, 304);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 10;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(222, 304);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtPlanoDiario
            // 
            txtPlanoDiario.Location = new Point(118, 126);
            txtPlanoDiario.Name = "txtPlanoDiario";
            txtPlanoDiario.Size = new Size(120, 23);
            txtPlanoDiario.TabIndex = 12;
            // 
            // txtPrecoKm
            // 
            txtPrecoKm.Location = new Point(119, 162);
            txtPrecoKm.Name = "txtPrecoKm";
            txtPrecoKm.Size = new Size(120, 23);
            txtPrecoKm.TabIndex = 13;
            // 
            // txtKmDisponivel
            // 
            txtKmDisponivel.Location = new Point(119, 198);
            txtKmDisponivel.Name = "txtKmDisponivel";
            txtKmDisponivel.Size = new Size(120, 23);
            txtKmDisponivel.TabIndex = 14;
            // 
            // TelaPlanoCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 344);
            Controls.Add(txtKmDisponivel);
            Controls.Add(txtPrecoKm);
            Controls.Add(txtPlanoDiario);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbTipoPlano);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbGrupoAutomovel);
            Name = "TelaPlanoCobrancaForm";
            Text = "TelaPlanoCobrancaForm";
            ((System.ComponentModel.ISupportInitialize)txtPlanoDiario).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKmDisponivel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbGrupoAutomovel;
        private Label label1;
        private Label label2;
        private ComboBox cmbTipoPlano;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnGravar;
        private Button btnCancelar;
        private NumericUpDown txtPlanoDiario;
        private NumericUpDown txtPrecoKm;
        private NumericUpDown txtKmDisponivel;
    }
}