namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.county")]
    public partial class county
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public county()
        {
            postcodes = new HashSet<postcode>();
        }

        [Key]
        public int idCountyListCode { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(9)]
        public string CountyCode { get; set; }

        [Required]
        [StringLength(45)]
        public string CountyName { get; set; }

        public int idCPDate { get; set; }

        public virtual cpdate cpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<postcode> postcodes { get; set; }
    }
}
