﻿namespace Aplicação_Avaliativa_P2
{
    partial class Consulta_de_Pedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            btnConsulta = new Button();
            lblNomeCliente = new Label();
            listView1 = new ListView();
            listView2 = new ListView();
            lblTotalPedido = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 0;
            label1.Text = "Informe o CPF para consulta:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 23);
            textBox1.TabIndex = 1;
            // 
            // btnConsulta
            // 
            btnConsulta.Location = new Point(27, 56);
            btnConsulta.Name = "btnConsulta";
            btnConsulta.Size = new Size(95, 32);
            btnConsulta.TabIndex = 2;
            btnConsulta.Text = "Consultar";
            btnConsulta.UseVisualStyleBackColor = true;
            btnConsulta.Click += btnConsulta_Click;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(12, 115);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(47, 15);
            lblNomeCliente.TabIndex = 3;
            lblNomeCliente.Text = "Cliente:";
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 133);
            listView1.Name = "listView1";
            listView1.Size = new Size(274, 146);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(333, 133);
            listView2.Name = "listView2";
            listView2.Size = new Size(359, 146);
            listView2.TabIndex = 5;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // lblTotalPedido
            // 
            lblTotalPedido.AutoSize = true;
            lblTotalPedido.Location = new Point(333, 282);
            lblTotalPedido.Name = "lblTotalPedido";
            lblTotalPedido.Size = new Size(93, 15);
            lblTotalPedido.TabIndex = 6;
            lblTotalPedido.Text = "Total Do Pedido:";
            // 
            // Consulta_de_Pedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTotalPedido);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(lblNomeCliente);
            Controls.Add(btnConsulta);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Consulta_de_Pedidos";
            Text = "Consulta_de_Pedidos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnConsulta;
        private Label lblNomeCliente;
        private ListView listView1;
        private ListView listView2;
        private Label lblTotalPedido;
    }
}