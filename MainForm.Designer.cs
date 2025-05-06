namespace StudentManagement
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.khoaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinhVienMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.quanLyMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(69, 20);
            this.fileMenu.Text = "Hệ thống";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Thoát";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // quanLyMenu
            // 
            this.quanLyMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.khoaMenuItem,
            this.sinhVienMenuItem});
            this.quanLyMenu.Name = "quanLyMenu";
            this.quanLyMenu.Size = new System.Drawing.Size(60, 20);
            this.quanLyMenu.Text = "Quản lý";
            // 
            // khoaMenuItem
            // 
            this.khoaMenuItem.Name = "khoaMenuItem";
            this.khoaMenuItem.Size = new System.Drawing.Size(180, 22);
            this.khoaMenuItem.Text = "Hồ sơ Khoa";
            this.khoaMenuItem.Click += new System.EventHandler(this.khoaMenuItem_Click);
            // 
            // sinhVienMenuItem
            // 
            this.sinhVienMenuItem.Name = "sinhVienMenuItem";
            this.sinhVienMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sinhVienMenuItem.Text = "Danh sách Sinh viên";
            this.sinhVienMenuItem.Click += new System.EventHandler(this.sinhVienMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 311);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyMenu;
        private System.Windows.Forms.ToolStripMenuItem khoaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinhVienMenuItem;
    }
}