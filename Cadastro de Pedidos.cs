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
    public partial class Cadastro_de_Pedidos : Form
    {
        private readonly string clientesCsvFilePAth = @"C:\Users\Usuario\Documents\GitHub\Aplicação_Avaliativa_P2\Aplicação_Avaliativa_P2\Clientes.csv";
        private readonly string produtosCsvFilePath = @"C:\Users\Usuario\Documents\GitHub\Aplicação_Avaliativa_P2\Aplicação_Avaliativa_P2\Produtos.csv";
        private readonly string pedidosCsvFilePath = @"C:\Users\Usuario\Documents\GitHub\Aplicação_Avaliativa_P2\Aplicação_Avaliativa_P2\Pedidos.csv";
        public Cadastro_de_Pedidos()
        {
            InitializeComponent();
        }

        private void BtnBuscaCpf_Click(object sender, EventArgs e)
        {

        }
    }
}
