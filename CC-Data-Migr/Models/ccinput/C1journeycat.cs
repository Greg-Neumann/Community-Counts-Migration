namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1journeycat")]
    public partial class C1journeycat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1journeycat()
        {
            C1service = new HashSet<C1service>();
        }

        [Key]
        public int idJourneyCat { get; set; }

        [Required]
        [StringLength(20)]
        public string CatName { get; set; }

        [Required]
        [StringLength(45)]
        public string CatDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1service> C1service { get; set; }
    }
}
