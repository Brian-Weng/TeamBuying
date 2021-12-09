namespace TeamBuying.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public Guid ID { get; set; }

        public Guid StoreID { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Picture { get; set; }

        public virtual Store Store { get; set; }
    }
}
