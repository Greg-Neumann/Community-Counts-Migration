namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.postcode")]
    public partial class postcode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public postcode()
        {
            C1client = new HashSet<C1client>();
            customers = new HashSet<customer>();
        }

        [Key]
        public int idPostCode { get; set; }

        [Column("PostCode", TypeName = "char")]
        [Required]
        [StringLength(8)]
        public string PostCode1 { get; set; }

        public int idWardCode { get; set; }

        public int idDistrictCode { get; set; }

        public int idCountyCode { get; set; }

        public int idNHSHACode { get; set; }

        public int idNHSRegHACode { get; set; }

        public int idCPDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1client> C1client { get; set; }

        public virtual county county { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer> customers { get; set; }

        public virtual district district { get; set; }

        public virtual nhspansha nhspansha { get; set; }

        public virtual nhssha nhssha { get; set; }

        public virtual ward ward { get; set; }
    }
}
