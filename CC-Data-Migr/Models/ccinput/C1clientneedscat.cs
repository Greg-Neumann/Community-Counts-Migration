namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1clientneedscat")]
    public partial class C1clientneedscat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1clientneedscat()
        {
            C1clientneedsdetail = new HashSet<C1clientneedsdetail>();
        }

        [Key]
        public int idNeedsCat { get; set; }

        [Required]
        [StringLength(60)]
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1clientneedsdetail> C1clientneedsdetail { get; set; }
    }
}
