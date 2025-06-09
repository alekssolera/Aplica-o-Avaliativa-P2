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
                    string response = await http.GetStringAsync(url);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ViaCepResponse>(response);
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
            string cep = textBox6.Text.Trim();
            string logradouro = textBox7.Text.Trim();
            string numero = textBox8.Text.Trim();
            string bairro = textBox9.Text.Trim();
            string cidade = textBox10.Text.Trim();
            string estado = textBox11.Text.Trim();
        }
    }
}
