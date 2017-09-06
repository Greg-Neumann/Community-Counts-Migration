namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1locations")]
    public partial class C1locations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1locations()
        {
            C1resources = new HashSet<C1resources>();
        }

        [Key]
        public int idLocations { get; set; }

        [Required]
        [StringLength(20)]
        public string LocationCode { get; set; }

        [Required]
        [StringLength(45)]
        public string LocationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1resources> C1resources { get; set; }
    }
}
