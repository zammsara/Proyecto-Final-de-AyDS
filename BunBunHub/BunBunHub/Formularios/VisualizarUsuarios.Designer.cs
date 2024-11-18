namespace BunBunHub.Formularios
{
    partial class VisualizarUsuarios
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TbpUsuarios = new System.Windows.Forms.TabPage();
            this.TbpClientes = new System.Windows.Forms.TabPage();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.BtnEliminarUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.DgvUsuarios = new System.Windows.Forms.DataGridView();
            this.BtngGuardarCambios = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TbpUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TbpUsuarios);
            this.tabControl1.Controls.Add(this.TbpClientes);
            this.tabControl1.Location = new System.Drawing.Point(23, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 399);
            this.tabControl1.TabIndex = 0;
            // 
            // TbpUsuarios
            // 
            this.TbpUsuarios.Controls.Add(this.BtngGuardarCambios);
            this.TbpUsuarios.Controls.Add(this.DgvUsuarios);
            this.TbpUsuarios.Controls.Add(this.CmbFiltro);
            this.TbpUsuarios.Controls.Add(this.label1);
            this.TbpUsuarios.Controls.Add(this.BtnEliminarUsuario);
            this.TbpUsuarios.Controls.Add(this.BtnFiltrar);
            this.TbpUsuarios.Location = new System.Drawing.Point(4, 22);
            this.TbpUsuarios.Name = "TbpUsuarios";
            this.TbpUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.TbpUsuarios.Size = new System.Drawing.Size(744, 373);
            this.TbpUsuarios.TabIndex = 0;
            this.TbpUsuarios.Text = "Usuarios";
            this.TbpUsuarios.UseVisualStyleBackColor = true;
            // 
            // TbpClientes
            // 
            this.TbpClientes.Location = new System.Drawing.Point(4, 22);
            this.TbpClientes.Name = "TbpClientes";
            this.TbpClientes.Padding = new System.Windows.Forms.Padding(3);
            this.TbpClientes.Size = new System.Drawing.Size(744, 373);
            this.TbpClientes.TabIndex = 1;
            this.TbpClientes.Text = "Clientes";
            this.TbpClientes.UseVisualStyleBackColor = true;
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Location = new System.Drawing.Point(650, 75);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.BtnFiltrar.TabIndex = 0;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            // 
            // BtnEliminarUsuario
            // 
            this.BtnEliminarUsuario.Location = new System.Drawing.Point(569, 303);
            this.BtnEliminarUsuario.Name = "BtnEliminarUsuario";
            this.BtnEliminarUsuario.Size = new System.Drawing.Size(75, 41);
            this.BtnEliminarUsuario.TabIndex = 1;
            this.BtnEliminarUsuario.Text = "Eliminar \r\nusuario\r\n";
            this.BtnEliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtrar por:";
            // 
            // CmbFiltro
            // 
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.Location = new System.Drawing.Point(604, 39);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(121, 21);
            this.CmbFiltro.TabIndex = 3;
            // 
            // DgvUsuarios
            // 
            this.DgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUsuarios.Location = new System.Drawing.Point(16, 25);
            this.DgvUsuarios.Name = "DgvUsuarios";
            this.DgvUsuarios.Size = new System.Drawing.Size(523, 319);
            this.DgvUsuarios.TabIndex = 4;
            // 
            // BtngGuardarCambios
            // 
            this.BtngGuardarCambios.Location = new System.Drawing.Point(650, 303);
            this.BtngGuardarCambios.Name = "BtngGuardarCambios";
            this.BtngGuardarCambios.Size = new System.Drawing.Size(75, 41);
            this.BtngGuardarCambios.TabIndex = 5;
            this.BtngGuardarCambios.Text = "Guardar \r\ncambios\r\n";
            this.BtngGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // VisualizarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "VisualizarUsuarios";
            this.Text = "VisualizarUsuarios";
            this.Load += new System.EventHandler(this.VisualizarUsuarios_Load);
            this.tabControl1.ResumeLayout(false);
            this.TbpUsuarios.ResumeLayout(false);
            this.TbpUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TbpUsuarios;
        private System.Windows.Forms.DataGridView DgvUsuarios;
        private System.Windows.Forms.ComboBox CmbFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEliminarUsuario;
        private System.Windows.Forms.Button BtnFiltrar;
        private System.Windows.Forms.TabPage TbpClientes;
        private System.Windows.Forms.Button BtngGuardarCambios;
    }
}