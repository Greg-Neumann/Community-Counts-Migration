namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1funders")]
    public partial class C1funders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1funders()
        {
            C1servicetypes = new HashSet<C1servicetypes>();
        }

        [Key]
        [StringLength(15)]
        public string FunderCode { get; set; }

        [StringLength(45)]
        public string FunderName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1servicetypes> C1servicetypes { get; set; }
    }
}
