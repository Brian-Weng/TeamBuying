namespace TeamBuying.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeamBuyingDetail
    {
        public Guid ID { get; set; }

        public Guid TeamBuyingID { get; set; }

        public Guid ProductID { get; set; }

        [Required]
        [StringLength(10)]
        public string Orderer { get; set; }

        public int Amount { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime CancelDate { get; set; }

        public virtual TeamBuying TeamBuying { get; set; }
    }
}
