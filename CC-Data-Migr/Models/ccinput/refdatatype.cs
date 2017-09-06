namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.refdatatype")]
    public partial class refdatatype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public refdatatype()
        {
            refdatas = new HashSet<refdata>();
        }

        [Key]
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string TypeCode { get; set; }

        [Required]
        [StringLength(45)]
        public string TypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<refdata> refdatas { get; set; }
    }
}
