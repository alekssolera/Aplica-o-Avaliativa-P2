using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;

namespace Aplicação_Avaliativa_P2
{
    public partial class Cadastro_de_Clientes : Form
    {
        private readonly string clientCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\Clientes.csv";

        public Cadastro_de_Clientes()
        {
            InitializeComponent();
        }

        private async void btnBusca_Click(object sender, EventArgs e)
        {
            string cep = textBox6.Text.Trim();
            if (string.IsNullOrEmpty(cep))
            {
                MessageBox.Show("Informe o CEP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var endereco = await ObterEnderecoViaCep(cep);
            if (endereco != null && endereco.Erro != true)
            {
                textBox7.Text = endereco.Logradouro;
                textBox8.Text = endereco.Bairro;
                textBox9.Text = endereco.Localidade;
                textBox10.Text = endereco.Uf;
            }
            else
            {
                MessageBox.Show("CEP não encontrado ou inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<ViaCepResponse> ObterEnderecoViaCep(string cep)
        {
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    string url = $"https://viacep.com.br/ws/{cep}/json/";
                    var response = await http.GetStringAsync(url);

                    var endereco = JsonSerializer.Deserialize<ViaCepResponse>(response,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    return endereco;
                }
                catch
                {
                    return null;
                }
            }
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text.Trim();
            string cpf = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string telefone = textBox4.Text.Trim();
            string WhatsApp = textBox5.Text.Trim();
            string cep = textBox6.Text.Trim();
            string logradouro = textBox7.Text.Trim();
            string numero = textBox8.Text.Trim();
            string bairro = textBox9.Text.Trim();
            string cidade = textBox10.Text.Trim();
            string estado = textBox11.Text.Trim();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(telefone) || string.IsNullOrEmpty(cep) || string.IsNullOrEmpty(logradouro) ||
                string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(bairro) || string.IsNullOrEmpty(cidade) ||
                string.IsNullOrEmpty(estado))
            {
                MessageBox.Show("Preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string dir = Path.GetDirectoryName(clientCsvFilePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (!File.Exists(clientCsvFilePath))
                {
                    using (var writer = new StreamWriter(clientCsvFilePath, false))
                    {
                        writer.WriteLine("Nome,CPF,Email,CEP,Logradouro,Numero,Bairro,Cidade,Estado,Telefone,WhatsApp");
                    }
                }

                using (var writer = new StreamWriter(clientCsvFilePath, true))
                {
                    var linha = $"\"{nome}\",\"{cpf}\",\"{email}\",\"{cep}\",\"{logradouro}\",\"{numero}\",\"{bairro}\",\"{cidade}\",\"{estado}\",\"{telefone}\",\"{WhatsApp}\"";
                    writer.WriteLine(linha);
                }
                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

        public class ViaCepResponse
        {
            public string? Cep { get; set; }
            public string? Logradouro { get; set; }
            public string? Complemento { get; set; }
            public string? Bairro { get; set; }
            public string? Localidade { get; set; }
            public string? Uf { get; set; }
            public bool? Erro { get; set; }
        }

        
    }
}
