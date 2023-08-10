namespace LocadoraVeiculo.ModuloCupom
{
    partial class TelaCupomForm
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
            txtNome = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtValor = new TextBox();
            label2 = new Label();
            DataValidade = new DateTimePicker();
            txtListaParceiro = new ComboBox();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(97, 36);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(338, 23);
            txtNome.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 143);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 10;
            label4.Text = "Parceiro:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 103);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 9;
            label3.Text = "Data Validade:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 39);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 8;
            label1.Text = "Nome:";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(373, 184);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 53);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = " Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(276, 184);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 53);
            btnGravar.TabIndex = 15;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click_1;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(97, 68);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(118, 23);
            txtValor.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 71);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 17;
            label2.Text = "Valor:";
            // 
            // DataValidade
            // 
            DataValidade.CustomFormat = "dd/mm/yyyy";
            DataValidade.Format = DateTimePickerFormat.Custom;
            DataValidade.Location = new Point(97, 103);
            DataValidade.Name = "DataValidade";
            DataValidade.Size = new Size(222, 23);
            DataValidade.TabIndex = 19;
            // 
            // txtListaParceiro
            // 
            txtListaParceiro.DropDownStyle = ComboBoxStyle.DropDownList;
            txtListaParceiro.FormattingEnabled = true;
            txtListaParceiro.Location = new Point(94, 140);
            txtListaParceiro.Name = "txtListaParceiro";
            txtListaParceiro.Size = new Size(341, 23);
            txtListaParceiro.TabIndex = 20;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 258);
            Controls.Add(txtListaParceiro);
            Controls.Add(DataValidade);
            Controls.Add(txtValor);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "TelaCupomForm";
            Text = "TelaCupomForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNome;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button btnCancelar;
        private Button btnGravar;
        private TextBox txtValor;
        private Label label2;
        private DateTimePicker DataValidade;
        private ComboBox txtListaParceiro;
    }
}