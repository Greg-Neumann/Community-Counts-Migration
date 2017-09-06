namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1clientcaseheader")]
    public partial class C1clientcaseheader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1clientcaseheader()
        {
            C1clientcasedocs = new HashSet<C1clientcasedocs>();
            C1clientcaseservice = new HashSet<C1clientcaseservice>();
        }

        [Key]
        public int idClientCaseHeader { get; set; }

        public int idClient { get; set; }

        public virtual C1client C1client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1clientcasedocs> C1clientcasedocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1clientcaseservice> C1clientcaseservice { get; set; }
    }
}
