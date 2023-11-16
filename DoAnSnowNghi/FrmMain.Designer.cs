namespace DoAnSnowNghi
{
    partial class FrmMain
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
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnHoaDonBan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCL = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnHangHoa = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripStatusLabelThanhVien1 = new System.Windows.Forms.ToolStripLabel();
            this.pnMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.LightCoral;
            this.pnMenu.Controls.Add(this.btnHoaDonBan);
            this.pnMenu.Controls.Add(this.button1);
            this.pnMenu.Controls.Add(this.btnCL);
            this.pnMenu.Controls.Add(this.btnKhachHang);
            this.pnMenu.Controls.Add(this.btnHangHoa);
            this.pnMenu.Controls.Add(this.btnNhanVien);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(140, 668);
            this.pnMenu.TabIndex = 0;
            // 
            // btnHoaDonBan
            // 
            this.btnHoaDonBan.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnHoaDonBan.Font = new System.Drawing.Font("Harlow Solid Italic", 11F, System.Drawing.FontStyle.Italic);
            this.btnHoaDonBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnHoaDonBan.Location = new System.Drawing.Point(6, 452);
            this.btnHoaDonBan.Name = "btnHoaDonBan";
            this.btnHoaDonBan.Size = new System.Drawing.Size(128, 56);
            this.btnHoaDonBan.TabIndex = 4;
            this.btnHoaDonBan.Text = "Hóa Đơn Bán";
            this.btnHoaDonBan.UseVisualStyleBackColor = false;
            this.btnHoaDonBan.Click += new System.EventHandler(this.btnHoaDonBan_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.button1.Font = new System.Drawing.Font("Harlow Solid Italic", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(6, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 56);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tìm Kiếm Hàng Hóa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCL
            // 
            this.btnCL.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnCL.Font = new System.Drawing.Font("Harlow Solid Italic", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCL.ForeColor = System.Drawing.Color.LightCoral;
            this.btnCL.Location = new System.Drawing.Point(6, 244);
            this.btnCL.Name = "btnCL";
            this.btnCL.Size = new System.Drawing.Size(128, 56);
            this.btnCL.TabIndex = 2;
            this.btnCL.Text = "Chất liệu";
            this.btnCL.UseVisualStyleBackColor = false;
            this.btnCL.Click += new System.EventHandler(this.btnCL_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnKhachHang.Font = new System.Drawing.Font("Harlow Solid Italic", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.LightCoral;
            this.btnKhachHang.Location = new System.Drawing.Point(6, 172);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(128, 56);
            this.btnKhachHang.TabIndex = 0;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnHangHoa.Font = new System.Drawing.Font("Harlow Solid Italic", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHangHoa.ForeColor = System.Drawing.Color.LightCoral;
            this.btnHangHoa.Location = new System.Drawing.Point(6, 313);
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.Size = new System.Drawing.Size(128, 56);
            this.btnHangHoa.TabIndex = 0;
            this.btnHangHoa.Text = "Hàng Hóa";
            this.btnHangHoa.UseVisualStyleBackColor = false;
            this.btnHangHoa.Click += new System.EventHandler(this.btnHangHoa_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnNhanVien.Font = new System.Drawing.Font("Harlow Solid Italic", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.LightCoral;
            this.btnNhanVien.Location = new System.Drawing.Point(6, 101);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(128, 56);
            this.btnNhanVien.TabIndex = 0;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.MistyRose;
            this.pnMain.Location = new System.Drawing.Point(140, 59);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1210, 600);
            this.pnMain.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(140, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 61);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelThanhVien1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1212, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripStatusLabelThanhVien1
            // 
            this.toolStripStatusLabelThanhVien1.Name = "toolStripStatusLabelThanhVien1";
            this.toolStripStatusLabelThanhVien1.Size = new System.Drawing.Size(111, 22);
            this.toolStripStatusLabelThanhVien1.Text = "toolStripLabel1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnMenu);
            this.Name = "FrmMain";
            this.Text = "Trang chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnHangHoa;
        private System.Windows.Forms.Button btnNhanVien;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnCL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripStatusLabelThanhVien1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHoaDonBan;
    }
}