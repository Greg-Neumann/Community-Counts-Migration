namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.nhssha")]
    public partial class nhssha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhssha()
        {
            postcodes = new HashSet<postcode>();
        }

        [Key]
        public int idNHSSHACode { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(9)]
        public string NHSSHACode { get; set; }

        [Required]
        [StringLength(45)]
        public string NHSSHAName { get; set; }

        public int idCPDate { get; set; }

        public virtual cpdate cpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<postcode> postcodes { get; set; }
    }
}
