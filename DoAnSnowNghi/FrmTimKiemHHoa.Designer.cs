namespace DoAnSnowNghi
{
    partial class FrmTimKiemHHoa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDanhsach = new System.Windows.Forms.DataGridView();
            this.Mahang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Machatlieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dongianhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dongiaban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.dgvDanhsach);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.txtKeyword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 580);
            this.panel1.TabIndex = 0;
            // 
            // dgvDanhsach
            // 
            this.dgvDanhsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhsach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mahang,
            this.Tenhang,
            this.Machatlieu,
            this.Soluong,
            this.Dongianhap,
            this.Dongiaban,
            this.Ghichu});
            this.dgvDanhsach.Location = new System.Drawing.Point(90, 217);
            this.dgvDanhsach.Name = "dgvDanhsach";
            this.dgvDanhsach.RowHeadersWidth = 51;
            this.dgvDanhsach.RowTemplate.Height = 24;
            this.dgvDanhsach.Size = new System.Drawing.Size(1044, 287);
            this.dgvDanhsach.TabIndex = 11;
            this.dgvDanhsach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhsach_CellContentClick);
            // 
            // Mahang
            // 
            this.Mahang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mahang.DataPropertyName = "Mahang";
            this.Mahang.HeaderText = "Mã Hàng";
            this.Mahang.MinimumWidth = 6;
            this.Mahang.Name = "Mahang";
            // 
            // Tenhang
            // 
            this.Tenhang.DataPropertyName = "Tenhang";
            this.Tenhang.HeaderText = "Tên Hàng";
            this.Tenhang.MinimumWidth = 6;
            this.Tenhang.Name = "Tenhang";
            // 
            // Machatlieu
            // 
            this.Machatlieu.DataPropertyName = "Machatlieu";
            this.Machatlieu.HeaderText = "Chất liệu";
            this.Machatlieu.MinimumWidth = 6;
            this.Machatlieu.Name = "Machatlieu";
            // 
            // Soluong
            // 
            this.Soluong.DataPropertyName = "Soluong";
            this.Soluong.HeaderText = "Số lượng";
            this.Soluong.MinimumWidth = 6;
            this.Soluong.Name = "Soluong";
            // 
            // Dongianhap
            // 
            this.Dongianhap.DataPropertyName = "Dongianhap";
            this.Dongianhap.HeaderText = "Đơn giá nhập";
            this.Dongianhap.MinimumWidth = 6;
            this.Dongianhap.Name = "Dongianhap";
            // 
            // Dongiaban
            // 
            this.Dongiaban.DataPropertyName = "Dongiaban";
            this.Dongiaban.HeaderText = "Đơn giá bán";
            this.Dongiaban.MinimumWidth = 6;
            this.Dongiaban.Name = "Dongiaban";
            // 
            // Ghichu
            // 
            this.Ghichu.DataPropertyName = "Ghichu";
            this.Ghichu.HeaderText = "Ghi Chú";
            this.Ghichu.MinimumWidth = 6;
            this.Ghichu.Name = "Ghichu";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(852, 138);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(106, 39);
            this.btnTim.TabIndex = 10;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click_1);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(510, 147);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(239, 30);
            this.txtKeyword.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nhập tên hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(434, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "TÌM KIẾM HÀNG HÓA";
            // 
            // FrmTimKiemHHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1352, 668);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTimKiemHHoa";
            this.Text = "FrmTimKiemHHoa";
            this.Load += new System.EventHandler(this.FrmTimKiemHHoa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDanhsach;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mahang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Machatlieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dongianhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dongiaban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ghichu;
    }
}