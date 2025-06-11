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
    public partial class Consulta_de_Pedidos : Form
    {
        private readonly string clientesCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\Clientes.csv";
        private readonly string pedidosCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\pedidos\Pedidos.csv";
        private readonly string itensPedidosCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\pedidos";

        private Dictionary<string, string> clientes = new Dictionary<string, string>();
        private List<Pedido> pedidos = new List<Pedido>();

        public Consulta_de_Pedidos()
        {
            InitializeComponent();
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            try
            {
                if (File.Exists(clientesCsvFilePath))
                {
                    var linhas = File.ReadAllLines(clientesCsvFilePath).Skip(1);
                    foreach (var linha in linhas)
                    {
                        var valores = linha.Split(',');
                        if (valores.Length > 1)
                        {
                            clientes[valores[1].Trim().Replace("\"", "")] = valores[0].Trim().Replace("\"", "");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConsulta_Click(object sender, EventArgs e)
        {

        }
    }
}
