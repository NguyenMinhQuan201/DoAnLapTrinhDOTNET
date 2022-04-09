namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongKe")]
    public partial class ThongKe
    {
        public int? Nam { get; set; }

        public decimal? Tong { get; set; }

        public int? Thang { get; set; }

        public int ID { get; set; }
    }
}
