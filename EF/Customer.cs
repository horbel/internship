namespace day2.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int ID { get; set; }

        public int? CartID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
