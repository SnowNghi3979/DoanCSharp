namespace DoAnSnowNghi.BAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHDBan { get; set; }

        public int? Mahang { get; set; }

        public int? Soluong { get; set; }

        public int? Dongia { get; set; }

        public int? Giamgia { get; set; }

        public int? Thanhtien { get; set; }
    }
}
