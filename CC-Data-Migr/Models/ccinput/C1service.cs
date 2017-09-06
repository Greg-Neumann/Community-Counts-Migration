namespace CC_Data_Migr.Models.ccinput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccbhlc.1service")]
    public partial class C1service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1service()
        {
            C1journeys = new HashSet<C1journeys>();
        }

        [Key]
        public int idService { get; set; }

        public int idClient { get; set; }

        public int idServiceType { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartedDate { get; set; }

        public int JourneyedidCategory { get; set; }

        public bool JourneyedServices { get; set; }

        public virtual C1client C1client { get; set; }

        public virtual C1journeycat C1journeycat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1journeys> C1journeys { get; set; }

        public virtual C1servicetypes C1servicetypes { get; set; }
    }
}
