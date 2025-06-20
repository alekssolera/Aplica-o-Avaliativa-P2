﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Aplicação_Avaliativa_P2
{
    public partial class Cadastro_de_Usuário : Form
    {
        private readonly string userCsvFilePath = @"C:\Users\Pichau\Desktop\Avaliação P2\Usuarios.csv";

        private readonly string currentUsername;
        private readonly string currentPassword;
        public Cadastro_de_Usuário(bool isAdmin, string username, string password)
        {
            InitializeComponent();

            currentUsername = username?.Trim() ?? string.Empty;
            currentPassword = password?.Trim() ?? string.Empty;

            bool isCurrentUserAdmin = IsAdminUser(); 
            btnCadastrar.Enabled = isCurrentUserAdmin;
            btnMudarSenha.Enabled = isCurrentUserAdmin;
            btnExcluir.Enabled = isCurrentUserAdmin;
        }

        private bool IsAdminUser()
        {
            return string.Equals(currentUsername, "ADMIN", StringComparison.OrdinalIgnoreCase) 
                && currentPassword == "123";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string directory = Path.GetDirectoryName(userCsvFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                Dictionary<string, string> users = LoadUsers();

                if (users.ContainsKey(username))
                {
                    MessageBox.Show("Usuário já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                users.Add(username, password);

                SaveUsers(users);

                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Clear();
                textBox2.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Dictionary<string, string> LoadUsers()
        {
            var users = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (File.Exists(userCsvFilePath))
            {
                foreach (var line in File.ReadLines(userCsvFilePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        string existingUsername = parts[0].Trim();
                        string existingPassword = parts[1].Trim();
                        if (!users.ContainsKey(existingUsername))
                        {
                            users.Add(existingUsername, existingPassword);
                        }
                    }
                }
            }
            return users;
        }
        private void SaveUsers(Dictionary<string, string> users)
        {
            using (var writer = new StreamWriter(userCsvFilePath, false))
            {
                foreach (var kvp in users)
                {
                    writer.WriteLine($"{kvp.Key},{kvp.Value}");
                }
            }
        }

        private void btnMudarSenha_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string newPassword = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Preencha usário  e nova senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var users = LoadUsers();

            if (users.ContainsKey(username))
            {
                users[username] = newPassword;

                SaveUsers(users);
                MessageBox.Show("Senha alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string usernameToDelete = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(usernameToDelete))
            {
                MessageBox.Show("Por favor, insira o nome de usuário a ser excluído.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var users = LoadUsers();

            if (!users.ContainsKey(usernameToDelete))
            {
                MessageBox.Show("Usuário não encontado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (string.Equals(usernameToDelete, "ADMIN", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Não é possível excluir o usuário ADMIN.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            users.Remove(usernameToDelete);
            SaveUsers(users);

            MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
