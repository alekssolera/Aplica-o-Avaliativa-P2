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
        private readonly string pedidosCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\Pedidos.csv";
        private readonly string itensPedidosDirectory = @"C:\Users\Pichau\Desktop\Avaliação P2\";

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
            string cpf  = textBox1.Text.Trim();
            if (!clientes.ContainsKey(cpf))
            {
                MessageBox.Show("Cliente não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lblNomeCliente.Text = clientes[cpf];
            CarregarPedidos(cpf);
        }

        private void CarregarPedidos(string cpf)
        {
            try
            {
                listView1.Items.Clear();
                pedidos.Clear();

                if (File.Exists(pedidosCsvFilePath))
                {
                    var linhas = File.ReadAllLines(pedidosCsvFilePath).Skip(1);
                    foreach (var linha in linhas)
                    {
                        var valores = linha.Split(',');
                        if (valores.Length > 1 && valores[1].Trim().Replace("\"", "") == cpf)
                        {
                            string idPedido = valores[0].Trim().Replace("\"", "");
                            DateTime dataPedido = DateTime.Parse(valores[2].Trim().Replace("\"", ""));
                            decimal totalPedido = decimal.Parse(valores[3].Trim().Replace("\"", ""));
                            pedidos.Add(new Pedido { idPedido = idPedido, cpfCliente = cpf, dataPedido = dataPedido, totalPedido = totalPedido });
                            listView1.Items.Add(new ListViewItem(new string[] { idPedido, dataPedido.ToString("g"), totalPedido.ToString("C") }));
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pedidos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string idPedido = listView1.SelectedItems[0].SubItems[0].Text;
                CarregarItensPedido(idPedido);
            }
        }

        private void CarregarItensPedido(string idPedido)
        {
            try
            {
                listView2.Items.Clear();
                string itensPedidosFilePath = Path.Combine(itensPedidosDirectory, $"itens_pedido_{idPedido}.csv");

                if (File.Exists(itensPedidosFilePath))
                {
                    var linhas = File.ReadAllLines(itensPedidosFilePath).Skip(1);
                    decimal totalPedido = 0;

                    foreach (var linha in linhas)
                    {
                        var valores = linha.Split(',');
                        if (valores.Length > 3)
                        {
                            string produto = valores[0].Trim().Replace("\"", "");
                            int quantidade = int.Parse(valores[1].Trim().Replace("\"", ""));
                            decimal precoUnitario = decimal.Parse(valores[2].Trim().Replace("\"", ""));
                            decimal totalItem = decimal.Parse(valores[3].Trim().Replace("\"", ""));

                            listView2.Items.Add(new ListViewItem(new[] { produto, quantidade.ToString(), precoUnitario.ToString("C"), totalItem.ToString("C") }));
                            totalPedido += totalItem;
                        }
                    }
                    lblTotalPedido.Text = $"Total do Pedido: {totalPedido:C}";
                }
                else
                {
                    MessageBox.Show("Itens do pedido não encontrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar itens do pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Pedido
        {
            public string idPedido { get; set; }
            public string cpfCliente { get; set; }
            public DateTime dataPedido { get; set; }
            public decimal totalPedido { get; set; }
        }
    }
}
