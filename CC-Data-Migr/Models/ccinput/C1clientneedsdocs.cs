namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1clientneedsdocs")]
    public partial class C1clientneedsdocs
    {
        [Key]
        public int idClientNeedsDocs { get; set; }

        public int idClientNeeds { get; set; }

        public DateTime ClientNeedsDocsDate { get; set; }

        [Required]
        [StringLength(255)]
        public string ClientNeedsDocsPath { get; set; }

        public virtual C1clientneedsheader C1clientneedsheader { get; set; }
    }
}
