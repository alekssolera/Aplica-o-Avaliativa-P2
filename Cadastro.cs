using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicação_Avaliativa_P2
{
    public partial class Cadastro : Form
    {
        private string password;
        private string username;
        private bool isAdmin;

        public Cadastro(bool isAdmin, string username, string password)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.username = username;
            this.password = password;
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            Cadastro_de_Usuário cadastroUsuarioForm = new Cadastro_de_Usuário(isAdmin, username, password);
            cadastroUsuarioForm.Show();
        }

        private void btnCadastroClientes_Click(object sender, EventArgs e)
        {
            Cadastro_de_Clientes cadastroClientesForm = new Cadastro_de_Clientes();
            cadastroClientesForm.Show();
        }

        private void btnCadastroProdutos_Click(object sender, EventArgs e)
        {
            Cadastro_de_Produtos cadastroProdutosForm = new Cadastro_de_Produtos();
            cadastroProdutosForm.Show();
        }

        private void btnCadastroPedidos_Click(object sender, EventArgs e)
        {
            Cadastro_de_Pedidos cadastroPedidosForm = new Cadastro_de_Pedidos();
            cadastroPedidosForm.Show();
        }
    }
}
