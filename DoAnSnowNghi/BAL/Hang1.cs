namespace DoAnSnowNghi.BAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hang1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mahang { get; set; }

        [StringLength(50)]
        public string Tenhang { get; set; }

        [StringLength(10)]
        public string Machatlieu { get; set; }

        public int? Soluong { get; set; }

        public int? Dongianhap { get; set; }

        public int? Dongiaban { get; set; }

        [Column(TypeName = "image")]
        public byte[] Anh { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }
    }
}
