namespace DoAnSnowNghi.BAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chatlieu1
    {
        [Key]
        [StringLength(10)]
        public string Machatlieu { get; set; }

        [StringLength(50)]
        public string Tenchatlieu { get; set; }
    }
}
