namespace hidohieu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaSanXuat()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        public int MaNSX { get; set; }

        [StringLength(50)]
        public string TenNSX { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Email { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
