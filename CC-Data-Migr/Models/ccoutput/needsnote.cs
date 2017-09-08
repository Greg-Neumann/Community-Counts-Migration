namespace CC_Data_Migr.Models.ccoutput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccmigr.needsnotes")]
    public partial class needsnote
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string idneeds { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(6)]
        public string idclient { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(8)]
        public string date { get; set; }

        [StringLength(16777215)]
        public string notes { get; set; }
    }
}
