namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KichCo")]
    public partial class KichCo
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string KichCoSP { get; set; }
    }
}
