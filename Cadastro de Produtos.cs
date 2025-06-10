using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicação_Avaliativa_P2
{
    public partial class Cadastro_de_Produtos : Form
    {
        private readonly string produtosCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\Produtos.Csv";
        public Cadastro_de_Produtos()
        {
            InitializeComponent();
            AtualizarContagemProdutos();
            
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text.Trim();
            string preco = textBox2.Text.Trim();
            string descricao = textBox3.Text.Trim();
            string quantidade = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(preco) || string.IsNullOrEmpty(descricao) || string.IsNullOrEmpty(quantidade))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK , MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(preco, out decimal precoDecimal))
            {
                MessageBox.Show("Preço Inválido. Insira um valor númerico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(quantidade, out int quantidadeInt) || quantidadeInt < 0)
            {
                MessageBox.Show("Quantidade Inválida. Insira um valor inteiro não negativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string dir = Path.GetDirectoryName(produtosCsvFilePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (!File.Exists(produtosCsvFilePath))
                {
                    using (var writer = new StreamWriter(produtosCsvFilePath, false, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine("Nome,Preço,Descrição,Quantidade");
                    }
                }

                using (var writer = new StreamWriter(produtosCsvFilePath, true, System.Text.Encoding.UTF8))
                {
                    var linha = $"\"{nome}\",\"{descricao}\",\"{precoDecimal}\",\"{quantidadeInt}\"";
                    writer.WriteLine(linha);
                }

                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                AtualizarContagemProdutos();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void AtualizarContagemProdutos()
        {
            try
            {
                if (File.Exists(produtosCsvFilePath))
                {
                    string[] linhas = File.ReadAllLines(produtosCsvFilePath);
                    int numeroDeProdutos = linhas.Length - 1;

                    lblTotalProduto.Text = $"Número de produtos cadastrados: {numeroDeProdutos}";
                }
                else
                {
                    lblTotalProduto.Text = "Número de produtos cadastrados: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar contagem de produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalProduto.Text = "Erro ao carregar contagem";
            }

        }
        
    }
}
