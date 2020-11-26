namespace FormProyect
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClientesBtn = new System.Windows.Forms.Button();
            this.VentasBtn = new System.Windows.Forms.Button();
            this.ProductosBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientesBtn
            // 
            this.ClientesBtn.BackColor = System.Drawing.Color.Chocolate;
            this.ClientesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesBtn.Location = new System.Drawing.Point(33, 12);
            this.ClientesBtn.Name = "ClientesBtn";
            this.ClientesBtn.Size = new System.Drawing.Size(202, 51);
            this.ClientesBtn.TabIndex = 0;
            this.ClientesBtn.Text = "CLIENTES";
            this.ClientesBtn.UseVisualStyleBackColor = false;
            this.ClientesBtn.Click += new System.EventHandler(this.ClientesBtn_Click);
            this.ClientesBtn.MouseEnter += new System.EventHandler(this.ClientesBtn_MouseEnter);
            this.ClientesBtn.MouseLeave += new System.EventHandler(this.ClientesBtn_MouseLeave);
            // 
            // VentasBtn
            // 
            this.VentasBtn.BackColor = System.Drawing.Color.Chocolate;
            this.VentasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VentasBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VentasBtn.Location = new System.Drawing.Point(33, 126);
            this.VentasBtn.Name = "VentasBtn";
            this.VentasBtn.Size = new System.Drawing.Size(202, 51);
            this.VentasBtn.TabIndex = 1;
            this.VentasBtn.Text = "VENTAS";
            this.VentasBtn.UseVisualStyleBackColor = false;
            this.VentasBtn.Click += new System.EventHandler(this.VentasBtn_Click);
            this.VentasBtn.MouseEnter += new System.EventHandler(this.VentasBtn_MouseEnter);
            this.VentasBtn.MouseLeave += new System.EventHandler(this.VentasBtn_MouseLeave);
            // 
            // ProductosBtn
            // 
            this.ProductosBtn.BackColor = System.Drawing.Color.Chocolate;
            this.ProductosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductosBtn.Location = new System.Drawing.Point(12, 69);
            this.ProductosBtn.Name = "ProductosBtn";
            this.ProductosBtn.Size = new System.Drawing.Size(249, 51);
            this.ProductosBtn.TabIndex = 2;
            this.ProductosBtn.Text = "PRODUCTOS";
            this.ProductosBtn.UseVisualStyleBackColor = false;
            this.ProductosBtn.Click += new System.EventHandler(this.ProductosBtn_Click);
            this.ProductosBtn.MouseEnter += new System.EventHandler(this.ProductosBtn_MouseEnter);
            this.ProductosBtn.MouseLeave += new System.EventHandler(this.ProductosBtn_MouseLeave);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(273, 197);
            this.Controls.Add(this.ProductosBtn);
            this.Controls.Add(this.VentasBtn);
            this.Controls.Add(this.ClientesBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuPrincipal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClientesBtn;
        private System.Windows.Forms.Button VentasBtn;
        private System.Windows.Forms.Button ProductosBtn;
    }
}

