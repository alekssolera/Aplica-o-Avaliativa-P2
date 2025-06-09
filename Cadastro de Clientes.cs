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
    }
}
