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
            btnCadastroClientes = new Button();
            btnCadastroProdutos = new Button();
            btnCadastroPedidos = new Button();
            btnCadastroUsuario = new Button();
            SuspendLayout();
            // 
            // btnCadastroClientes
            // 
            btnCadastroClientes.Location = new Point(245, 76);
            btnCadastroClientes.Name = "btnCadastroClientes";
            btnCadastroClientes.Size = new Size(193, 38);
            btnCadastroClientes.TabIndex = 0;
            btnCadastroClientes.Text = "Cadastro de Cliente";
            btnCadastroClientes.UseVisualStyleBackColor = true;
            btnCadastroClientes.Click += btnCadastroClientes_Click;
            // 
            // btnCadastroProdutos
            // 
            btnCadastroProdutos.Location = new Point(245, 120);
            btnCadastroProdutos.Name = "btnCadastroProdutos";
            btnCadastroProdutos.Size = new Size(193, 36);
            btnCadastroProdutos.TabIndex = 1;
            btnCadastroProdutos.Text = "Cadastro de Produtos";
            btnCadastroProdutos.UseVisualStyleBackColor = true;
            btnCadastroProdutos.Click += btnCadastroProdutos_Click;
            // 
            // btnCadastroPedidos
            // 
            btnCadastroPedidos.Location = new Point(245, 162);
            btnCadastroPedidos.Name = "btnCadastroPedidos";
            btnCadastroPedidos.Size = new Size(193, 37);
            btnCadastroPedidos.TabIndex = 2;
            btnCadastroPedidos.Text = "Cadastro de Pedidos";
            btnCadastroPedidos.UseVisualStyleBackColor = true;
            // 
            // btnCadastroUsuario
            // 
            btnCadastroUsuario.Location = new Point(245, 37);
            btnCadastroUsuario.Name = "btnCadastroUsuario";
            btnCadastroUsuario.Size = new Size(193, 33);
            btnCadastroUsuario.TabIndex = 3;
            btnCadastroUsuario.Text = "Cadastro de Usuário";
            btnCadastroUsuario.UseVisualStyleBackColor = true;
            btnCadastroUsuario.Click += btnCadastroUsuario_Click;
            // 
            // Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCadastroUsuario);
            Controls.Add(btnCadastroPedidos);
            Controls.Add(btnCadastroProdutos);
            Controls.Add(btnCadastroClientes);
            Name = "Cadastro";
            Text = "Cadastro";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCadastroClientes;
        private Button btnCadastroProdutos;
        private Button btnCadastroPedidos;
        private Button btnCadastroUsuario;
    }
}