namespace LocadoraVeiculo.ModuloConfiguracaoPreco
{
    partial class TelaConfiguracaoPrecoForm
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
            txtGasolina = new NumericUpDown();
            txtGas = new NumericUpDown();
            txtDiesel = new NumericUpDown();
            txtAlcool = new NumericUpDown();
            btnGravar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)txtGasolina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAlcool).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 35);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Gasolina";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 71);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 1;
            label2.Text = "Gás";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 108);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 2;
            label3.Text = "Diesel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 150);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 3;
            label4.Text = "Álcool";
            // 
            // txtGasolina
            // 
            txtGasolina.Location = new Point(116, 33);
            txtGasolina.Name = "txtGasolina";
            txtGasolina.Size = new Size(120, 23);
            txtGasolina.TabIndex = 4;
            // 
            // txtGas
            // 
            txtGas.Location = new Point(116, 69);
            txtGas.Name = "txtGas";
            txtGas.Size = new Size(120, 23);
            txtGas.TabIndex = 5;
            // 
            // txtDiesel
            // 
            txtDiesel.Location = new Point(116, 106);
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(120, 23);
            txtDiesel.TabIndex = 6;
            // 
            // txtAlcool
            // 
            txtAlcool.Location = new Point(116, 148);
            txtAlcool.Name = "txtAlcool";
            txtAlcool.Size = new Size(120, 23);
            txtAlcool.TabIndex = 7;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(116, 221);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 8;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(205, 221);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaConfiguracaoPrecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 276);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtAlcool);
            Controls.Add(txtDiesel);
            Controls.Add(txtGas);
            Controls.Add(txtGasolina);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaConfiguracaoPrecoForm";
            Text = "TelaConfiguracaoPrecoForm";
            ((System.ComponentModel.ISupportInitialize)txtGasolina).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAlcool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown txtGasolina;
        private NumericUpDown txtGas;
        private NumericUpDown txtDiesel;
        private NumericUpDown txtAlcool;
        private Button btnGravar;
        private Button btnCancelar;
    }
}