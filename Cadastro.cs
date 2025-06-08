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
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            Cadastro_de_Usuário cadastroUsuarioForm = new Cadastro_de_Usuário();
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
    }
}
