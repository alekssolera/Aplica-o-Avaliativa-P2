﻿namespace Aplicação_Avaliativa_P2
{
    partial class Cadastro_de_Usuário
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
            btnCadastrar = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            btnMudarSenha = new Button();
            btnExcluir = new Button();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(381, 164);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(200, 40);
            btnCadastrar.TabIndex = 0;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(381, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(381, 26);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuário:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(381, 104);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 23);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(381, 86);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 4;
            label2.Text = "Senha:";
            // 
            // btnMudarSenha
            // 
            btnMudarSenha.Location = new Point(381, 237);
            btnMudarSenha.Name = "btnMudarSenha";
            btnMudarSenha.Size = new Size(200, 42);
            btnMudarSenha.TabIndex = 5;
            btnMudarSenha.Text = "Mudar Senha";
            btnMudarSenha.UseVisualStyleBackColor = true;
            btnMudarSenha.Click += btnMudarSenha_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(381, 308);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(200, 37);
            btnExcluir.TabIndex = 6;
            btnExcluir.Text = "Excluir Usuário";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // Cadastro_de_Usuário
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 450);
            Controls.Add(btnExcluir);
            Controls.Add(btnMudarSenha);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnCadastrar);
            Name = "Cadastro_de_Usuário";
            Text = "Cadastro_de_Usuário";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCadastrar;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private Button btnMudarSenha;
        private Button btnExcluir;
    }
}