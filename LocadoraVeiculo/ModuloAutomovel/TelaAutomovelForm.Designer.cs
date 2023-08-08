namespace LocadoraVeiculo.ModuloAutomovel
{
    partial class TelaAutomovelForm
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
            txtModelo = new TextBox();
            label2 = new Label();
            txtCor = new TextBox();
            label3 = new Label();
            txtMarca = new TextBox();
            label4 = new Label();
            txtCapacidadeLitros = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtPlaca = new TextBox();
            label7 = new Label();
            txtQuilometragem = new TextBox();
            label8 = new Label();
            label9 = new Label();
            fotoAutomovel = new PictureBox();
            openFileDialog = new OpenFileDialog();
            btnBuscar = new Button();
            txtAno = new NumericUpDown();
            label10 = new Label();
            txtListaGrupoAutomovel = new ComboBox();
            txtListaTipoCombustivel = new ComboBox();
            bntCancelar = new Button();
            btnGravar = new Button();
            ((System.ComponentModel.ISupportInitialize)fotoAutomovel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAno).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 205);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 5;
            label1.Text = "Grupo De Automoveis:";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(140, 238);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(199, 23);
            txtModelo.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 241);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "Modelo:";
            // 
            // txtCor
            // 
            txtCor.Location = new Point(140, 316);
            txtCor.Name = "txtCor";
            txtCor.Size = new Size(199, 23);
            txtCor.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 319);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 11;
            label3.Text = "Cor:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(140, 278);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(199, 23);
            txtMarca.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 281);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 9;
            label4.Text = "Marca:";
            // 
            // txtCapacidadeLitros
            // 
            txtCapacidadeLitros.Location = new Point(140, 389);
            txtCapacidadeLitros.Name = "txtCapacidadeLitros";
            txtCapacidadeLitros.Size = new Size(199, 23);
            txtCapacidadeLitros.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 392);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 15;
            label5.Text = "Capacidade em Litros:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 358);
            label6.Name = "label6";
            label6.Size = new Size(119, 15);
            label6.TabIndex = 13;
            label6.Text = "Tipo de Combustível:";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(140, 465);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(199, 23);
            txtPlaca.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(91, 473);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 19;
            label7.Text = "Placa:";
            // 
            // txtQuilometragem
            // 
            txtQuilometragem.Location = new Point(140, 427);
            txtQuilometragem.Name = "txtQuilometragem";
            txtQuilometragem.Size = new Size(199, 23);
            txtQuilometragem.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 430);
            label8.Name = "label8";
            label8.Size = new Size(94, 15);
            label8.TabIndex = 17;
            label8.Text = "Quilometragem:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(95, 88);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 21;
            label9.Text = "Foto:";
            // 
            // fotoAutomovel
            // 
            fotoAutomovel.Location = new Point(140, 12);
            fotoAutomovel.Name = "fotoAutomovel";
            fotoAutomovel.Size = new Size(427, 181);
            fotoAutomovel.TabIndex = 22;
            fotoAutomovel.TabStop = false;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(590, 48);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(111, 69);
            btnBuscar.TabIndex = 23;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // txtAno
            // 
            txtAno.Location = new Point(140, 505);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(120, 23);
            txtAno.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(91, 507);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 25;
            label10.Text = "Ano:";
            // 
            // txtListaGrupoAutomovel
            // 
            txtListaGrupoAutomovel.FormattingEnabled = true;
            txtListaGrupoAutomovel.Location = new Point(140, 202);
            txtListaGrupoAutomovel.Name = "txtListaGrupoAutomovel";
            txtListaGrupoAutomovel.Size = new Size(427, 23);
            txtListaGrupoAutomovel.TabIndex = 26;
            // 
            // txtListaTipoCombustivel
            // 
            txtListaTipoCombustivel.FormattingEnabled = true;
            txtListaTipoCombustivel.Location = new Point(140, 350);
            txtListaTipoCombustivel.Name = "txtListaTipoCombustivel";
            txtListaTipoCombustivel.Size = new Size(427, 23);
            txtListaTipoCombustivel.TabIndex = 27;
            // 
            // bntCancelar
            // 
            bntCancelar.DialogResult = DialogResult.Cancel;
            bntCancelar.Location = new Point(615, 550);
            bntCancelar.Name = "bntCancelar";
            bntCancelar.Size = new Size(75, 53);
            bntCancelar.TabIndex = 29;
            bntCancelar.Text = " Cancelar";
            bntCancelar.UseVisualStyleBackColor = true;
            bntCancelar.Click += bntCancelar_Click;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(518, 550);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 53);
            btnGravar.TabIndex = 28;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 630);
            Controls.Add(bntCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtListaTipoCombustivel);
            Controls.Add(txtListaGrupoAutomovel);
            Controls.Add(label10);
            Controls.Add(txtAno);
            Controls.Add(btnBuscar);
            Controls.Add(fotoAutomovel);
            Controls.Add(label9);
            Controls.Add(txtPlaca);
            Controls.Add(label7);
            Controls.Add(txtQuilometragem);
            Controls.Add(label8);
            Controls.Add(txtCapacidadeLitros);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(txtCor);
            Controls.Add(label3);
            Controls.Add(txtMarca);
            Controls.Add(label4);
            Controls.Add(txtModelo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaAutomovelForm";
            Text = "TelaAutomovelForm";
            ((System.ComponentModel.ISupportInitialize)fotoAutomovel).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private Label label1;
        private TextBox txtModelo;
        private Label label2;
        private TextBox txtCor;
        private Label label3;
        private TextBox txtMarca;
        private Label label4;
        private TextBox txtCapacidadeLitros;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private TextBox txtPlaca;
        private Label label7;
        private TextBox txtQuilometragem;
        private Label label8;
        private Label label9;
        private PictureBox fotoAutomovel;
        private OpenFileDialog openFileDialog;
        private Button btnBuscar;
        private NumericUpDown txtAno;
        private Label label10;
        private ComboBox txtListaGrupoAutomovel;
        private ComboBox txtListaTipoCombustivel;
        private Button bntCancelar;
        private Button btnGravar;
    }
}