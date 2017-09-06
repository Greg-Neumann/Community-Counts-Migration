namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1servicetypes")]
    public partial class C1servicetypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1servicetypes()
        {
            C1attendance = new HashSet<C1attendance>();
            C1bookings = new HashSet<C1bookings>();
            C1clientcaseservice = new HashSet<C1clientcaseservice>();
            C1schedules = new HashSet<C1schedules>();
            C1service = new HashSet<C1service>();
            C1surveys = new HashSet<C1surveys>();
        }

        [Key]
        public int idServiceType { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceType { get; set; }

        public int AttendanceType { get; set; }

        [Required]
        [StringLength(15)]
        public string FunderCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1attendance> C1attendance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1bookings> C1bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1clientcaseservice> C1clientcaseservice { get; set; }

        public virtual C1funders C1funders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1schedules> C1schedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1service> C1service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1surveys> C1surveys { get; set; }

        public virtual refdata refdata { get; set; }
    }
}
