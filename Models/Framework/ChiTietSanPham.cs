namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        public int ID { get; set; }

        public int IDSanPham { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public int? IDLoaiSanPham { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        public decimal? Gia { get; set; }

        [StringLength(50)]
        public string Mota { get; set; }

        [StringLength(50)]
        public string MauSacSP { get; set; }

        [StringLength(50)]
        public string KichCoSP { get; set; }

        public int? SoLuong { get; set; }

        public int? LuotXem { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
