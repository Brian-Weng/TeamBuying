namespace TeamBuying.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            TeamBuyings = new HashSet<TeamBuying>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(10)]
        public string UserAccount { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public virtual AccountInfo AccountInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamBuying> TeamBuyings { get; set; }
    }
}
