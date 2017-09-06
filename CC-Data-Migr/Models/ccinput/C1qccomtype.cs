namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1qccomtype")]
    public partial class C1qccomtype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1qccomtype()
        {
            C1qccom = new HashSet<C1qccom>();
        }

        [Key]
        public int idQCComType { get; set; }

        [Required]
        [StringLength(30)]
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1qccom> C1qccom { get; set; }
    }
}
