namespace hidohieu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDDHs = new HashSet<ChiTietDDH>();
        }

        [Key]
        public int MaSanPham { get; set; }

        public int MaLoai { get; set; }

        public int MaNSX { get; set; }

        public int MaNCC { get; set; }

        [StringLength(250)]
        public string TenSanPham { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        [StringLength(500)]
        public string Mota { get; set; }

        [StringLength(50)]
        public string AnhSanPham { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapNhat { get; set; }

        public int? SoLuongTon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDDH> ChiTietDDHs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
