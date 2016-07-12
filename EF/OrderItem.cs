namespace day2.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderItem")]
    public partial class OrderItem
    {
        public int ID { get; set; }

        public int? OrderID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public virtual Order Order { get; set; }
    }
}
