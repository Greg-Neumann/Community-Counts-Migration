namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1clientcaseservicedetail")]
    public partial class C1clientcaseservicedetail
    {
        [Key]
        public int idClientCaseServiceDetail { get; set; }

        public int idClientCaseDetail { get; set; }

        public TimeSpan CaseServiceTime { get; set; }

        public DateTime CaseServiceDate { get; set; }

        public int? CaseServiceStaffid { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string CaseServiceNotes { get; set; }

        public DateTime? CaseServiceEditDate { get; set; }

        public virtual C1clientcaseservice C1clientcaseservice { get; set; }

        public virtual user user { get; set; }
    }
}
