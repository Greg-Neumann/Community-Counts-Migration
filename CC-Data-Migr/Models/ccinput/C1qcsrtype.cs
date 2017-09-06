namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1qcsrtype")]
    public partial class C1qcsrtype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1qcsrtype()
        {
            C1qcsr = new HashSet<C1qcsr>();
        }

        [Key]
        public int idQCSRType { get; set; }

        [Required]
        [StringLength(30)]
        public string QCSRType { get; set; }

        public bool Signpost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1qcsr> C1qcsr { get; set; }
    }
}
