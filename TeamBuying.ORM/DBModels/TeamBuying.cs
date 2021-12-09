namespace TeamBuying.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeamBuying
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeamBuying()
        {
            TeamBuyingDetails = new HashSet<TeamBuyingDetail>();
        }

        public Guid ID { get; set; }

        public Guid AccountID { get; set; }

        public Guid StoreID { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Body { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Status { get; set; }

        public virtual Account Account { get; set; }

        public virtual Store Store { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamBuyingDetail> TeamBuyingDetails { get; set; }
    }
}
