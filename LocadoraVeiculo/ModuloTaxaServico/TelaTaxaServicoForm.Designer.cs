namespace LocadoraVeiculo.ModuloTaxaServico
{
    partial class TelaTaxaServicoForm
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
            label1 = new Label();
            label2 = new Label();
            txtNome = new TextBox();
            txtPreco = new TextBox();
            groupBox1 = new GroupBox();
            rdbCobrancaDiaria = new RadioButton();
            rdbPrecoFixo = new RadioButton();
            btnGravar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 29);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 64);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Preço";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(84, 26);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(292, 23);
            txtNome.TabIndex = 2;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(84, 61);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(126, 23);
            txtPreco.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbCobrancaDiaria);
            groupBox1.Controls.Add(rdbPrecoFixo);
            groupBox1.Location = new Point(40, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(336, 100);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Plano de Calculo";
            // 
            // rdbCobrancaDiaria
            // 
            rdbCobrancaDiaria.AutoSize = true;
            rdbCobrancaDiaria.Location = new Point(180, 42);
            rdbCobrancaDiaria.Name = "rdbCobrancaDiaria";
            rdbCobrancaDiaria.Size = new Size(109, 19);
            rdbCobrancaDiaria.TabIndex = 1;
            rdbCobrancaDiaria.TabStop = true;
            rdbCobrancaDiaria.Text = "Cobrança Diária";
            rdbCobrancaDiaria.UseVisualStyleBackColor = true;
            // 
            // rdbPrecoFixo
            // 
            rdbPrecoFixo.AutoSize = true;
            rdbPrecoFixo.Location = new Point(31, 42);
            rdbPrecoFixo.Name = "rdbPrecoFixo";
            rdbPrecoFixo.Size = new Size(80, 19);
            rdbPrecoFixo.TabIndex = 0;
            rdbPrecoFixo.TabStop = true;
            rdbPrecoFixo.Text = "Preço Fixo";
            rdbPrecoFixo.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(220, 221);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(301, 221);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaTaxaServicoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 262);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(txtPreco);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaTaxaServicoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Taxa e Serviços";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNome;
        private TextBox txtPreco;
        private GroupBox groupBox1;
        private RadioButton rdbCobrancaDiaria;
        private RadioButton rdbPrecoFixo;
        private Button btnGravar;
        private Button btnCancelar;
    }
}