namespace CC_Data_Migr.Models.ccoutput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccmigr.needs")]
    public partial class need
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string idneeds { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(6)]
        public string idclient { get; set; }

        [Required]
        [StringLength(60)]
        public string needscategory { get; set; }
    }
}
