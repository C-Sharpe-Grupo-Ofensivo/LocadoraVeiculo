namespace LocadoraVeiculo.ModuloCliente
{
    partial class TelaClienteForm
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
            label3 = new Label();
            rdnPessoaFisica = new RadioButton();
            rdnPessoaJuridica = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtEstado = new TextBox();
            txtCidade = new TextBox();
            txtBairro = new TextBox();
            txtRua = new TextBox();
            txtNumero = new TextBox();
            txtCpf = new MaskedTextBox();
            txtCnpj = new MaskedTextBox();
            txtTelefone = new MaskedTextBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 87);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Telefone";
            // 
            // rdnPessoaFisica
            // 
            rdnPessoaFisica.AutoSize = true;
            rdnPessoaFisica.Location = new Point(99, 117);
            rdnPessoaFisica.Name = "rdnPessoaFisica";
            rdnPessoaFisica.Size = new Size(93, 19);
            rdnPessoaFisica.TabIndex = 3;
            rdnPessoaFisica.TabStop = true;
            rdnPessoaFisica.Text = "Pessoa Fisica";
            rdnPessoaFisica.UseVisualStyleBackColor = true;
            rdnPessoaFisica.CheckedChanged += rdnPessoaFisica_CheckedChanged;
            // 
            // rdnPessoaJuridica
            // 
            rdnPessoaJuridica.AutoSize = true;
            rdnPessoaJuridica.Location = new Point(246, 117);
            rdnPessoaJuridica.Name = "rdnPessoaJuridica";
            rdnPessoaJuridica.Size = new Size(104, 19);
            rdnPessoaJuridica.TabIndex = 4;
            rdnPessoaJuridica.TabStop = true;
            rdnPessoaJuridica.Text = "Pessoa Juridica";
            rdnPessoaJuridica.UseVisualStyleBackColor = true;
            rdnPessoaJuridica.CheckedChanged += rdnPessoaJuridica_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 121);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 5;
            label4.Text = "Tipo Cliente";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 158);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 6;
            label5.Text = "Cpf";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(256, 158);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 7;
            label6.Text = "Cnpj";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 189);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 8;
            label7.Text = "Estado";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(256, 189);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 9;
            label8.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 226);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 10;
            label9.Text = "Bairro";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 260);
            label10.Name = "label10";
            label10.Size = new Size(27, 15);
            label10.TabIndex = 11;
            label10.Text = "Rua";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 292);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 12;
            label11.Text = "Numero";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(71, 26);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(269, 23);
            txtNome.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(71, 54);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(269, 23);
            txtEmail.TabIndex = 14;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(56, 186);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(122, 23);
            txtEstado.TabIndex = 16;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(306, 186);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(118, 23);
            txtCidade.TabIndex = 17;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(56, 223);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(284, 23);
            txtBairro.TabIndex = 18;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(56, 255);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(284, 23);
            txtRua.TabIndex = 19;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(56, 284);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(122, 23);
            txtNumero.TabIndex = 20;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(56, 155);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(122, 23);
            txtCpf.TabIndex = 21;
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(306, 155);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(100, 23);
            txtCnpj.TabIndex = 22;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(71, 83);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(107, 23);
            txtTelefone.TabIndex = 23;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(246, 383);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 24;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(349, 383);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 25;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 417);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtTelefone);
            Controls.Add(txtCnpj);
            Controls.Add(txtCpf);
            Controls.Add(txtNumero);
            Controls.Add(txtRua);
            Controls.Add(txtBairro);
            Controls.Add(txtCidade);
            Controls.Add(txtEstado);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(rdnPessoaJuridica);
            Controls.Add(rdnPessoaFisica);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaClienteForm";
            Text = "TelaClienteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton rdnPessoaFisica;
        private RadioButton rdnPessoaJuridica;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtEstado;
        private TextBox txtCidade;
        private TextBox txtBairro;
        private TextBox txtRua;
        private TextBox txtNumero;
        private MaskedTextBox txtCpf;
        private MaskedTextBox txtCnpj;
        private MaskedTextBox txtTelefone;
        private Button btnGravar;
        private Button btnCancelar;
    }
}