namespace Aplicação_Avaliativa_P2
{
    public partial class Form1 : Form
    {
        private readonly string userCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\Usuarios.csv";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CredenciaisValidas(username, password))
            {
                OpenCadastroForm(username, password);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos. Tente novamente.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CredenciaisValidas(string username, string password)
        {
            if (username.Equals("ADMIN", StringComparison.OrdinalIgnoreCase) && password == "123")
                return true;

            if (File.Exists(userCsvFilePath))
            {
                var lines = File.ReadAllLines(userCsvFilePath);
                foreach (var line in File.ReadAllLines(userCsvFilePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        string user = parts[0].Trim();
                        string pass = parts[1].Trim();
                        if (user.Equals(username, StringComparison.OrdinalIgnoreCase) && pass == password)
                            return true;
                    }
                }
            }

            return false;
        }
        private void  OpenCadastroForm(string username, string password)
        {
            bool isAdmin = username.Equals("ADMIN", StringComparison.OrdinalIgnoreCase) && password == "123";
            
            Cadastro cadastroForm = new Cadastro(isAdmin, username, password);
            cadastroForm.Show();
        }
    }
}
