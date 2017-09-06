namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1clientcasedocs")]
    public partial class C1clientcasedocs
    {
        [Key]
        public int idClientCaseDocs { get; set; }

        public int idClientCase { get; set; }

        public DateTime ClientCaseDocsDate { get; set; }

        [Required]
        [StringLength(255)]
        public string ClientCaseDocsPath { get; set; }

        public virtual C1clientcaseheader C1clientcaseheader { get; set; }
    }
}
