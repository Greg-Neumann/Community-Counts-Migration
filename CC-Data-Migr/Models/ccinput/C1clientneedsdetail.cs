namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1clientneedsdetail")]
    public partial class C1clientneedsdetail
    {
        [Key]
        public int idClientNeedsDetail { get; set; }

        public int idClientNeedsCat { get; set; }

        public int idClientNeeds { get; set; }

        public bool hasThisNeed { get; set; }

        public virtual C1clientneedscat C1clientneedscat { get; set; }

        public virtual C1clientneedsheader C1clientneedsheader { get; set; }
    }
}
