namespace LocadoraVeiculo.ModuloCondutor
{
    partial class TelaCondutorForm
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
            txtCnh = new MaskedTextBox();
            txtCpf = new MaskedTextBox();
            txtTelefone = new MaskedTextBox();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            label7 = new Label();
            dateValidade = new DateTimePicker();
            label6 = new Label();
            label4 = new Label();
            chEhCondutor = new CheckBox();
            cbCliente = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            checkBox1 = new CheckBox();
            bntCancelar = new Button();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // txtCnh
            // 
            txtCnh.Location = new Point(88, 167);
            txtCnh.Mask = "99,999,999/9999-99";
            txtCnh.Name = "txtCnh";
            txtCnh.Size = new Size(100, 23);
            txtCnh.TabIndex = 114;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(225, 138);
            txtCpf.Mask = "999,999,999-99";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(93, 23);
            txtCpf.TabIndex = 113;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(88, 138);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(100, 23);
            txtTelefone.TabIndex = 112;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(88, 80);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(230, 23);
            txtNome.TabIndex = 111;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(88, 109);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 23);
            txtEmail.TabIndex = 110;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 200);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 109;
            label7.Text = "Validade:";
            // 
            // dateValidade
            // 
            dateValidade.Format = DateTimePickerFormat.Short;
            dateValidade.Location = new Point(88, 196);
            dateValidade.Name = "dateValidade";
            dateValidade.Size = new Size(100, 23);
            dateValidade.TabIndex = 108;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 170);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 107;
            label6.Text = "CNH:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(194, 141);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 106;
            label4.Text = "CPF:";
            // 
            // chEhCondutor
            // 
            chEhCondutor.AutoSize = true;
            chEhCondutor.Location = new Point(88, 55);
            chEhCondutor.Name = "chEhCondutor";
            chEhCondutor.Size = new Size(124, 19);
            chEhCondutor.TabIndex = 105;
            chEhCondutor.Text = "Cliente é condutor";
            chEhCondutor.UseVisualStyleBackColor = true;
            // 
            // cbCliente
            // 
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(88, 23);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(230, 23);
            cbCliente.TabIndex = 104;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 141);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 103;
            label5.Text = "Telefone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 112);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 102;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 83);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 101;
            label2.Text = "Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 26);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 100;
            label1.Text = "Cliente:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(64, 260);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(124, 19);
            checkBox1.TabIndex = 115;
            checkBox1.Text = "Cliente é condutor";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // bntCancelar
            // 
            bntCancelar.DialogResult = DialogResult.Cancel;
            bntCancelar.Location = new Point(185, 338);
            bntCancelar.Name = "bntCancelar";
            bntCancelar.Size = new Size(75, 53);
            bntCancelar.TabIndex = 117;
            bntCancelar.Text = " Cancelar";
            bntCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(88, 338);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 53);
            btnGravar.TabIndex = 116;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click_1;
            // 
            // TelaCondutorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 450);
            Controls.Add(bntCancelar);
            Controls.Add(btnGravar);
            Controls.Add(checkBox1);
            Controls.Add(txtCnh);
            Controls.Add(txtCpf);
            Controls.Add(txtTelefone);
            Controls.Add(txtNome);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(dateValidade);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(chEhCondutor);
            Controls.Add(cbCliente);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaCondutorForm";
            Text = "TelaCondutorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox txtCnh;
        private MaskedTextBox txtCpf;
        private MaskedTextBox txtTelefone;
        private TextBox txtNome;
        private TextBox txtEmail;
        private Label label7;
        private DateTimePicker dateValidade;
        private Label label6;
        private Label label4;
        private CheckBox chEhCondutor;
        private ComboBox cbCliente;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox checkBox1;
        private Button bntCancelar;
        private Button btnGravar;
    }
}