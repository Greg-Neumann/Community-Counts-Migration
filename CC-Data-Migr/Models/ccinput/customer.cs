namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            C1client = new HashSet<C1client>();
        }

        [Key]
        public int idCust { get; set; }

        [Required]
        [StringLength(45)]
        public string CustName { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(10)]
        public string CustShortName { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string Number { get; set; }

        [Required]
        [StringLength(45)]
        public string AddressLine1 { get; set; }

        [StringLength(45)]
        public string AddressLine2 { get; set; }

        public int idCity { get; set; }

        public int? idCounty { get; set; }

        public int idPostCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1client> C1client { get; set; }

        public virtual citylist citylist { get; set; }

        public virtual countylist countylist { get; set; }

        public virtual postcode postcode { get; set; }
    }
}
