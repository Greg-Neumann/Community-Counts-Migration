namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1journeys")]
    public partial class C1journeys
    {
        [Key]
        public int idJourneys { get; set; }

        public int OrigidService { get; set; }

        public int JourneyedidService { get; set; }

        public int JourneyDepth { get; set; }

        public virtual C1service C1service { get; set; }
    }
}
