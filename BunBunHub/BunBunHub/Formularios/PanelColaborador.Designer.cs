namespace BunBunHub.Formularios
{
    partial class PanelColaborador
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
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblPaneldeControl = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.btnPedidosCo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSistema.BackgroundImage = global::BunBunHub.Properties.Resources.CerrarSistemaCeleste;
            this.btnCerrarSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSistema.FlatAppearance.BorderSize = 0;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Location = new System.Drawing.Point(776, 11);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(24, 24);
            this.btnCerrarSistema.TabIndex = 118;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.BackgroundImage = global::BunBunHub.Properties.Resources.btnCerrarSesion;
            this.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 462);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(126, 33);
            this.btnCerrarSesion.TabIndex = 119;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblPaneldeControl
            // 
            this.lblPaneldeControl.AutoSize = true;
            this.lblPaneldeControl.BackColor = System.Drawing.Color.Transparent;
            this.lblPaneldeControl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaneldeControl.ForeColor = System.Drawing.Color.SeaShell;
            this.lblPaneldeControl.Location = new System.Drawing.Point(252, 142);
            this.lblPaneldeControl.Name = "lblPaneldeControl";
            this.lblPaneldeControl.Size = new System.Drawing.Size(251, 41);
            this.lblPaneldeControl.TabIndex = 121;
            this.lblPaneldeControl.Text = "Panel de Control";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.SeaShell;
            this.lblBienvenido.Location = new System.Drawing.Point(242, 182);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(265, 15);
            this.lblBienvenido.TabIndex = 120;
            this.lblBienvenido.Text = "Bienvenido al Panel de Control de Colaboradores";
            // 
            // btnPedidosCo
            // 
            this.btnPedidosCo.BackColor = System.Drawing.Color.White;
            this.btnPedidosCo.BackgroundImage = global::BunBunHub.Properties.Resources.BtnPedidos;
            this.btnPedidosCo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPedidosCo.FlatAppearance.BorderSize = 0;
            this.btnPedidosCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidosCo.Location = new System.Drawing.Point(223, 254);
            this.btnPedidosCo.Name = "btnPedidosCo";
            this.btnPedidosCo.Size = new System.Drawing.Size(153, 199);
            this.btnPedidosCo.TabIndex = 122;
            this.btnPedidosCo.UseVisualStyleBackColor = false;
            // 
            // PanelColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BunBunHub.Properties.Resources.FondoPanelAdministrador;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(810, 518);
            this.Controls.Add(this.btnPedidosCo);
            this.Controls.Add(this.lblPaneldeControl);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnCerrarSistema);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PanelColaborador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PanelColaborador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblPaneldeControl;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Button btnPedidosCo;
    }
}