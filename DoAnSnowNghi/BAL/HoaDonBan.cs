namespace DoAnSnowNghi.BAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonBan")]
    public partial class HoaDonBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHDBan { get; set; }

        public int? Manhanvien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayban { get; set; }

        public int? Makhach { get; set; }

        public double? Tongtien { get; set; }
    }
}
