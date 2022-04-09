namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [StringLength(50)]
        public string Images { get; set; }

        public decimal? Gia { get; set; }

        [StringLength(50)]
        public string MauSacSP { get; set; }

        [StringLength(50)]
        public string KichCoSP { get; set; }

        public int IDHoaDon { get; set; }

        public int ID { get; set; }

        public int? Soluong { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
