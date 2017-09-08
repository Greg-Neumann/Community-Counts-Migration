namespace CC_Data_Migr.Models.ccoutput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccmigr.casework")]
    public partial class casework
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string idcasework { get; set; }

        [Column(TypeName = "char")]
        [StringLength(6)]
        public string idclient { get; set; }

        [Required]
        [StringLength(45)]
        public string activity { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(5)]
        public string time { get; set; }

        [Column(TypeName = "char")]
        [StringLength(19)]
        public string date { get; set; }

        [StringLength(45)]
        public string staff { get; set; }

        [StringLength(16777215)]
        public string notes { get; set; }
    }
}
