namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.ward")]
    public partial class ward
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ward()
        {
            postcodes = new HashSet<postcode>();
        }

        [Key]
        public int idWardCode { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(9)]
        public string WardCode { get; set; }

        [Required]
        [StringLength(70)]
        public string Description { get; set; }

        public int idCPDate { get; set; }

        public virtual cpdate cpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<postcode> postcodes { get; set; }
    }
}
