namespace DoAnSnowNghi.BAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Khach2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Makhach { get; set; }

        [StringLength(50)]
        public string Tenkhach { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [StringLength(50)]
        public string Dienthoai { get; set; }
    }
}
