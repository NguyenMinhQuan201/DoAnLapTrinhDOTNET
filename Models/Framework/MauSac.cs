namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MauSac")]
    public partial class MauSac
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string MauSacSP { get; set; }
    }
}
