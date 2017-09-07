namespace CC_Data_Migr.Models.ccoutput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccmigr.activity")]
    public partial class activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(6)]
        public string idactivity { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(6)]
        public string idclient { get; set; }

        [Required]
        [StringLength(45)]
        public string activityname { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(19)]
        public string createdate { get; set; }

        [Column(TypeName = "char")]
        [StringLength(19)]
        public string UnenrolledDate { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(19)]
        public string enrolleddate { get; set; }
    }
}
