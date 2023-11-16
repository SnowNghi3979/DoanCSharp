namespace DoAnSnowNghi.BAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NguoiDung1
    {
        [Key]
        [StringLength(200)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(200)]
        public string MatKhau { get; set; }
    }
}
