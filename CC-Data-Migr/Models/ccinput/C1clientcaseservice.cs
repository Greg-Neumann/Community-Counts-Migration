namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1clientcaseservice")]
    public partial class C1clientcaseservice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1clientcaseservice()
        {
            C1clientcaseservicedetail = new HashSet<C1clientcaseservicedetail>();
        }

        [Key]
        public int idClientCaseDetail { get; set; }

        public int idClientCaseHeader { get; set; }

        public int ServiceTypesid { get; set; }

        public bool isCaseWorked { get; set; }

        public virtual C1clientcaseheader C1clientcaseheader { get; set; }

        public virtual C1servicetypes C1servicetypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1clientcaseservicedetail> C1clientcaseservicedetail { get; set; }
    }
}
