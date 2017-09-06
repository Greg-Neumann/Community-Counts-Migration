namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1resourcetypes")]
    public partial class C1resourcetypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1resourcetypes()
        {
            C1resources = new HashSet<C1resources>();
        }

        [Key]
        [StringLength(30)]
        public string ResourceType { get; set; }

        [Required]
        [StringLength(60)]
        public string ResourceTypeDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1resources> C1resources { get; set; }
    }
}
