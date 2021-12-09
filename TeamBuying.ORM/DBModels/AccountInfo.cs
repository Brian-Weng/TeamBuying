namespace TeamBuying.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountInfos")]
    public partial class AccountInfo
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Photo { get; set; }

        public virtual Account Account { get; set; }
    }
}
