namespace Aplicação_Avaliativa_P2
{
    partial class Cadastro_de_Pedidos
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            BtnBuscaCpf = new Button();
            listBox1 = new ListBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            btnAdicionarPedido = new Button();
            btnFinalizarPedido = new Button();
            lblTotalPedido = new Label();
            btnConsultaPedidos = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(116, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 1;
            label1.Text = "CPF Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 16);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 2;
            label2.Text = "Cliente:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(180, 34);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 23);
            textBox2.TabIndex = 3;
            // 
            // BtnBuscaCpf
            // 
            BtnBuscaCpf.Location = new Point(31, 63);
            BtnBuscaCpf.Name = "BtnBuscaCpf";
            BtnBuscaCpf.Size = new Size(75, 23);
            BtnBuscaCpf.TabIndex = 4;
            BtnBuscaCpf.Text = "Buscar CPF";
            BtnBuscaCpf.UseVisualStyleBackColor = true;
            BtnBuscaCpf.Click += BtnBuscaCpf_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 210);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(776, 139);
            listBox1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 163);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(154, 23);
            comboBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 7;
            label3.Text = "Selecione Os Produtos:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(209, 163);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(122, 23);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(209, 145);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 9;
            label4.Text = "Quantidade:";
            // 
            // btnAdicionarPedido
            // 
            btnAdicionarPedido.Location = new Point(362, 162);
            btnAdicionarPedido.Name = "btnAdicionarPedido";
            btnAdicionarPedido.Size = new Size(184, 23);
            btnAdicionarPedido.TabIndex = 10;
            btnAdicionarPedido.Text = "Adicionar ao Pedido";
            btnAdicionarPedido.UseVisualStyleBackColor = true;
            btnAdicionarPedido.Click += btnAdicionarPedido_Click;
            // 
            // btnFinalizarPedido
            // 
            btnFinalizarPedido.Location = new Point(649, 355);
            btnFinalizarPedido.Name = "btnFinalizarPedido";
            btnFinalizarPedido.Size = new Size(139, 42);
            btnFinalizarPedido.TabIndex = 11;
            btnFinalizarPedido.Text = "Finalizar Pedido";
            btnFinalizarPedido.UseVisualStyleBackColor = true;
            btnFinalizarPedido.Click += btnFinalizarPedido_Click;
            // 
            // lblTotalPedido
            // 
            lblTotalPedido.AutoSize = true;
            lblTotalPedido.Location = new Point(12, 352);
            lblTotalPedido.Name = "lblTotalPedido";
            lblTotalPedido.Size = new Size(92, 15);
            lblTotalPedido.TabIndex = 12;
            lblTotalPedido.Text = "Total do Pedido:";
            // 
            // btnConsultaPedidos
            // 
            btnConsultaPedidos.Location = new Point(498, 366);
            btnConsultaPedidos.Name = "btnConsultaPedidos";
            btnConsultaPedidos.Size = new Size(123, 31);
            btnConsultaPedidos.TabIndex = 13;
            btnConsultaPedidos.Text = "Consulta de Pedidos";
            btnConsultaPedidos.UseVisualStyleBackColor = true;
            // 
            // Cadastro_de_Pedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConsultaPedidos);
            Controls.Add(lblTotalPedido);
            Controls.Add(btnFinalizarPedido);
            Controls.Add(btnAdicionarPedido);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(listBox1);
            Controls.Add(BtnBuscaCpf);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Cadastro_de_Pedidos";
            Text = "Cadastro_de_Pedidos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button BtnBuscaCpf;
        private ListBox listBox1;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Button btnAdicionarPedido;
        private Button btnFinalizarPedido;
        private Label lblTotalPedido;
        private Button btnConsultaPedidos;
    }
}