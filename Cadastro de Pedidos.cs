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
                        if (valores.Length > 2 && decimal.TryParse(valores[2].Trim().Replace("\"", ""), out decimal preco))
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
            string cpf = textBox1.Text.Trim();
            if (clientes.ContainsKey(cpf))
            {
                textBox2.Text = clientes[cpf];
            }
            else
            {
                MessageBox.Show("CPF não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
            }
        }

        private void btnAdicionarPedido_Click(object sender, EventArgs e)
        {
            string produto = comboBox1.SelectedItem as string;
            if (string.IsNullOrEmpty(produto))
            {
                MessageBox.Show("Selecione um produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!produtos.ContainsKey(produto))
            {
                MessageBox.Show("Produto não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(textBox3.Text.Trim(), out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Quantidade inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal precoUnitario = produtos[produto];
            decimal totalItem = precoUnitario * quantidade;

            itensPedido.Add(new OrderItem { produto = produto, Quantidade = quantidade, PrecoUnitario = precoUnitario, TotalItem = totalItem });
            AtualizarListaItens();
            textBox3.Clear();
        }

        private void AtualizarListaItens()
        {
            listBox1.Items.Clear();
            decimal totalPedido = 0;
            foreach (var item in itensPedido)
            {
                listBox1.Items.Add($"{item.produto} - Qtd: {item.Quantidade} X Preço Unitário: {item.PrecoUnitario:C} = Total: {item.TotalItem:C}");
                totalPedido += item.TotalItem;
            }
            lblTotalPedido.Text = $"Total do Pedido: {totalPedido:C}";
        }

        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            string cpf = textBox1.Text.Trim();
            if (!clientes.ContainsKey(cpf))
            {
                MessageBox.Show("CPF do cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (itensPedido.Count == 0)
            {
                MessageBox.Show("Nenhum item adicionado ao pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idPedido = Guid.NewGuid().ToString();

                string dir = Path.GetDirectoryName(pedidosCsvFilePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                using (var writer = new StreamWriter(pedidosCsvFilePath, true, System.Text.Encoding.UTF8))
                {
                    decimal totalPedido = itensPedido.Sum(item => item.TotalItem);
                    string linha = $"\"{idPedido}\",\"{cpf}\",\"{DateTime.Now}\",\"{totalPedido}\"";
                    writer.WriteLine(linha);

                    string itensFilePath = Path.Combine(dir, $"itens_pedido_{idPedido}.csv");
                    using (var itensWriter = new StreamWriter(itensFilePath, false, System.Text.Encoding.UTF8))
                    {
                        itensWriter.WriteLine("Produto,Quantidade,PrecoUnitario,TotalItem");
                        foreach (var item in itensPedido)
                        {
                            string  linhaItem = $"\"{item.produto}\",\"{item.Quantidade}\",\"{item.PrecoUnitario}\",\"{item.TotalItem}\"";
                            itensWriter.WriteLine(linhaItem);
                        }
                    }
                }
                MessageBox.Show("Pedido salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
