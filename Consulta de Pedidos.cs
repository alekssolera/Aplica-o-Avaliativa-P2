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
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            ConfigurarListViewItensPedido();
            CarregarClientes();
        }

        private void ConfigurarListViewItensPedido()
        {
            listView2.View = View.Details;
            listView2.Columns.Clear();
            listView2.Columns.Add("Produto", 150);
            listView2.Columns.Add("Quantidade", 100);
            listView2.Columns.Add("Preço Unitário", 100);
            listView2.Columns.Add("Total Item", 100);
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
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
                        if (valores.Length > 3 && valores[1].Trim().Replace("\"", "") == cpf)
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
                            string quantidadeStr = (valores[1].Trim().Replace("\"", ""));
                            string precoUnitario = (valores[2].Trim().Replace("\"", ""));
                            string totalItem = (valores[3].Trim().Replace("\"", ""));

                            if (int.TryParse(quantidadeStr , out int quantidade) &&
                                decimal.TryParse(precoUnitario, out decimal precoUnitarioStr) &&
                                decimal.TryParse(totalItem, out decimal totalItemStr))
                            {
                                ListViewItem item = new ListViewItem(produto);
                                item.SubItems.Add(quantidade.ToString());
                                item.SubItems.Add(precoUnitarioStr.ToString("C"));
                                item.SubItems.Add(totalItemStr.ToString("C"));
                                listView2.Items.Add(item);
                                totalPedido += totalItemStr;
                            }
                        }
                    }
                    lblTotalPedido.Text = $"Total do Pedido: {totalPedido:C}";
                }
                else
                {
                    MessageBox.Show("Itens do pedido não encontrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listView2.Items.Clear();
                    lblTotalPedido.Text = "Total do Pedido: R$ 0,00";
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
