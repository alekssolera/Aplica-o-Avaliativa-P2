namespace Aplicação_Avaliativa_P2
{
    partial class Cadastro
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
            btnCadastro = new Button();
            SuspendLayout();
            // 
            // btnCadastro
            // 
            btnCadastro.Location = new Point(245, 34);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(193, 38);
            btnCadastro.TabIndex = 0;
            btnCadastro.Text = "Cadastro de Cliente";
            btnCadastro.UseVisualStyleBackColor = true;
            // 
            // Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCadastro);
            Name = "Cadastro";
            Text = "Cadastro";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCadastro;
    }
}