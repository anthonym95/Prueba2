namespace WinInventarioHogar
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.Sidebar = new System.Windows.Forms.Panel();
            this.btnOpciones = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.Content = new System.Windows.Forms.Panel();
            this.Navbar = new System.Windows.Forms.Panel();
            this.msAdmin = new System.Windows.Forms.MenuStrip();
            this.tsmiRegistro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCategoriasRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.msUsuario = new System.Windows.Forms.MenuStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.Sidebar.SuspendLayout();
            this.Navbar.SuspendLayout();
            this.msAdmin.SuspendLayout();
            this.msUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sidebar
            // 
            this.Sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(57)))));
            this.Sidebar.Controls.Add(this.btnOpciones);
            this.Sidebar.Controls.Add(this.btnReportes);
            this.Sidebar.Controls.Add(this.btnProductos);
            this.Sidebar.Controls.Add(this.btnInicio);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.Location = new System.Drawing.Point(0, 0);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Size = new System.Drawing.Size(125, 561);
            this.Sidebar.TabIndex = 0;
            // 
            // btnOpciones
            // 
            this.btnOpciones.BackColor = System.Drawing.Color.Transparent;
            this.btnOpciones.FlatAppearance.BorderSize = 0;
            this.btnOpciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpciones.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpciones.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOpciones.Image = global::WinInventarioHogar.Properties.Resources.Services_50px;
            this.btnOpciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpciones.Location = new System.Drawing.Point(0, 386);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(125, 82);
            this.btnOpciones.TabIndex = 4;
            this.btnOpciones.Text = "Opciones";
            this.btnOpciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpciones.UseVisualStyleBackColor = false;
            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.Transparent;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReportes.Image = global::WinInventarioHogar.Properties.Resources.Bar_Chart_50px;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReportes.Location = new System.Drawing.Point(0, 298);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(125, 82);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.Transparent;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProductos.Image = global::WinInventarioHogar.Properties.Resources.Barcode_50px;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProductos.Location = new System.Drawing.Point(0, 210);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(125, 82);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInicio.Image = global::WinInventarioHogar.Properties.Resources.Home_50px;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInicio.Location = new System.Drawing.Point(0, 122);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(125, 82);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // Content
            // 
            this.Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(125, 40);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(1059, 521);
            this.Content.TabIndex = 2;
            // 
            // Navbar
            // 
            this.Navbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.Navbar.Controls.Add(this.msAdmin);
            this.Navbar.Controls.Add(this.msUsuario);
            this.Navbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Navbar.Location = new System.Drawing.Point(125, 0);
            this.Navbar.Name = "Navbar";
            this.Navbar.Size = new System.Drawing.Size(1059, 40);
            this.Navbar.TabIndex = 1;
            // 
            // msAdmin
            // 
            this.msAdmin.AutoSize = false;
            this.msAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.msAdmin.Dock = System.Windows.Forms.DockStyle.None;
            this.msAdmin.GripMargin = new System.Windows.Forms.Padding(0);
            this.msAdmin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.msAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRegistro});
            this.msAdmin.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.msAdmin.Location = new System.Drawing.Point(833, 0);
            this.msAdmin.Name = "msAdmin";
            this.msAdmin.Padding = new System.Windows.Forms.Padding(0);
            this.msAdmin.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.msAdmin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.msAdmin.Size = new System.Drawing.Size(226, 40);
            this.msAdmin.TabIndex = 0;
            this.msAdmin.Visible = false;
            // 
            // tsmiRegistro
            // 
            this.tsmiRegistro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUsuarios,
            this.tsmiCategoriasRoles});
            this.tsmiRegistro.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsmiRegistro.ForeColor = System.Drawing.SystemColors.Control;
            this.tsmiRegistro.Image = global::WinInventarioHogar.Properties.Resources.Add_List_32px;
            this.tsmiRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiRegistro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiRegistro.Name = "tsmiRegistro";
            this.tsmiRegistro.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsmiRegistro.ShowShortcutKeys = false;
            this.tsmiRegistro.Size = new System.Drawing.Size(122, 40);
            this.tsmiRegistro.Text = "Registro";
            // 
            // tsmiUsuarios
            // 
            this.tsmiUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.tsmiUsuarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsmiUsuarios.Name = "tsmiUsuarios";
            this.tsmiUsuarios.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsmiUsuarios.ShowShortcutKeys = false;
            this.tsmiUsuarios.Size = new System.Drawing.Size(234, 30);
            this.tsmiUsuarios.Text = "Usuarios";
            this.tsmiUsuarios.Click += new System.EventHandler(this.tsmiUsuarios_Click);
            // 
            // tsmiCategoriasRoles
            // 
            this.tsmiCategoriasRoles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsmiCategoriasRoles.Name = "tsmiCategoriasRoles";
            this.tsmiCategoriasRoles.ShowShortcutKeys = false;
            this.tsmiCategoriasRoles.Size = new System.Drawing.Size(234, 30);
            this.tsmiCategoriasRoles.Text = "Categorías y Roles";
            this.tsmiCategoriasRoles.Click += new System.EventHandler(this.tsmiCategoriasRoles_Click);
            // 
            // msUsuario
            // 
            this.msUsuario.AutoSize = false;
            this.msUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.msUsuario.Dock = System.Windows.Forms.DockStyle.None;
            this.msUsuario.GripMargin = new System.Windows.Forms.Padding(0);
            this.msUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.msUsuario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario});
            this.msUsuario.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.msUsuario.Location = new System.Drawing.Point(0, 0);
            this.msUsuario.Name = "msUsuario";
            this.msUsuario.Padding = new System.Windows.Forms.Padding(0);
            this.msUsuario.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.msUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.msUsuario.Size = new System.Drawing.Size(1150, 40);
            this.msUsuario.TabIndex = 0;
            // 
            // lblUsuario
            // 
            this.lblUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSalir});
            this.lblUsuario.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsuario.Image = global::WinInventarioHogar.Properties.Resources.Male_User_32px;
            this.lblUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(0);
            this.lblUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUsuario.ShowShortcutKeys = false;
            this.lblUsuario.Size = new System.Drawing.Size(115, 40);
            this.lblUsuario.Text = "usuario";
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.tsmiSalir.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiSalir.ShowShortcutKeys = false;
            this.tsmiSalir.Size = new System.Drawing.Size(191, 30);
            this.tsmiSalir.Text = "Cerrar Sesión";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Navbar);
            this.Controls.Add(this.Sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario - Hogar Jafeth Jiménez";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Sidebar.ResumeLayout(false);
            this.Navbar.ResumeLayout(false);
            this.msAdmin.ResumeLayout(false);
            this.msAdmin.PerformLayout();
            this.msUsuario.ResumeLayout(false);
            this.msUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Sidebar;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnOpciones;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Panel Navbar;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegistro;
        private System.Windows.Forms.MenuStrip msAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiCategoriasRoles;
        private System.Windows.Forms.MenuStrip msUsuario;
        private System.Windows.Forms.ToolStripMenuItem lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
    }
}

