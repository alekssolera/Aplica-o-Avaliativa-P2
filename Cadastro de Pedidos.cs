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

        private Dictionary<string, string> clientes = new Dictionary<string, string>();
        private Dictionary<string, decimal> produtos = new Dictionary<string, decimal>();
        private List<OrderItem> itensPedido = new List<OrderItem>();

        public Cadastro_de_Pedidos()
        {
            InitializeComponent();
            CarregarClientes();
            CarregarProdutos();
            CarregarProdutosNaComboBox();
            AtualizarListaItens();
        }

        private void CarregarClientes()
        {
            try
            {
                if (File.Exists(clientesCsvFilePAth))
                {
                    var linhas = File.ReadAllLines(clientesCsvFilePAth).Skip(1);
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

        private void CarregarProdutos()
        {
            try
            {
                if (File.Exists(produtosCsvFilePath))
                {
                    var linhas = File.ReadAllLines(produtosCsvFilePath).Skip(1);
                    foreach (var linha in linhas)
                    {
                        var valores = linha.Split(',');
                        if (valores.Length > 2 && decimal.TryParse(valores[2].Trim( ).Replace("\"", ""), out decimal preco))
                        {
                            produtos[valores[0].Trim().Replace("\"", "")] = preco;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarProdutosNaComboBox()
        {
            try
            {
                comboBox1.Items.Clear();
                foreach (var produto in produtos.Keys)
                {
                    comboBox1.Items.Add(produto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos na ComboBox: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscaCpf_Click(object sender, EventArgs e)
        {
           
        }
    }
}
