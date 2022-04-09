namespace Models.Framework
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
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        [Key]
        public int IDSanPham { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public int? IDLoaiSanPham { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        public decimal? Gia { get; set; }

        [StringLength(50)]
        public string Mota { get; set; }

        public int? Rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
