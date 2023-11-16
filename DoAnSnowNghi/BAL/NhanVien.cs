namespace DoAnSnowNghi.BAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Manhanvien { get; set; }

        [StringLength(50)]
        public string Tennhanvien { get; set; }

        [StringLength(50)]
        public string Gioitinh { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [StringLength(50)]
        public string Dienthoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }
    }
}
