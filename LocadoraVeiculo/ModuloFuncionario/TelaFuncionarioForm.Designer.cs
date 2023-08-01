namespace LocadoraVeiculo.ModuloFuncionario
{
    partial class TelaFuncionarioForm
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
            label4 = new Label();
            txtId = new TextBox();
            txtNome = new TextBox();
            dtpAdmissao = new DateTimePicker();
            txtSalario = new TextBox();
            btnCancelar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 66);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 25);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 0;
            label2.Text = "Id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 104);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 1;
            label3.Text = "Admissâo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 145);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 2;
            label4.Text = "Salário";
            // 
            // txtId
            // 
            txtId.AccessibleRole = AccessibleRole.None;
            txtId.Location = new Point(93, 22);
            txtId.Name = "txtId";
            txtId.Size = new Size(38, 23);
            txtId.TabIndex = 3;
            txtId.Text = "1";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(93, 63);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(405, 23);
            txtNome.TabIndex = 4;
            // 
            // dtpAdmissao
            // 
            dtpAdmissao.Location = new Point(93, 104);
            dtpAdmissao.Name = "dtpAdmissao";
            dtpAdmissao.Size = new Size(239, 23);
            dtpAdmissao.TabIndex = 5;
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(93, 142);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(239, 23);
            txtSalario.TabIndex = 6;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.OK;
            btnCancelar.Location = new Point(340, 186);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 53);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Gravar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(440, 186);
            button1.Name = "button1";
            button1.Size = new Size(75, 53);
            button1.TabIndex = 8;
            button1.Text = " Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // TelaFuncionarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 265);
            Controls.Add(button1);
            Controls.Add(btnCancelar);
            Controls.Add(txtSalario);
            Controls.Add(dtpAdmissao);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaFuncionarioForm";
            Text = "TelaFuncionarioForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtId;
        private TextBox txtNome;
        private DateTimePicker dtpAdmissao;
        private TextBox txtSalario;
        private Button btnCancelar;
        private Button button1;
    }
}