namespace Aplicação_Avaliativa_P2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (CredenciaisValidas(username, password))
            {
                Cadastro cadastroForm = new Cadastro();
                cadastroForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos. Tente novamente.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
