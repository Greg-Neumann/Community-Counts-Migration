namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1surressca")]
    public partial class C1surressca
    {
        [Key]
        public int idSurResSca { get; set; }

        public int idSurvey { get; set; }

        public int idClient { get; set; }

        public int ScaledQ { get; set; }

        public int IDResponse { get; set; }

        public int responseSeqNo { get; set; }

        public virtual C1client C1client { get; set; }

        public virtual refdata refdata { get; set; }

        public virtual C1surveys C1surveys { get; set; }
    }
}
