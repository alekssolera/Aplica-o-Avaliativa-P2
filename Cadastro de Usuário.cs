using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Aplicação_Avaliativa_P2
{
    public partial class Cadastro_de_Usuário : Form
    {
        private readonly string userCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2";
        public Cadastro_de_Usuário()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
        }
    }
}
