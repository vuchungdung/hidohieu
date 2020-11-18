namespace hidohieu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        [Key]
        public int MaLH { get; set; }

        [StringLength(50)]
        public string Ho { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapNhat { get; set; }
    }
}
