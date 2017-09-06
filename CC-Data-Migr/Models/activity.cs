namespace CC_Data_Migr.Models
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
        public int idactivity { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(6)]
        public string idclient { get; set; }

        [Required]
        [StringLength(45)]
        public string activityname { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(10)]
        public string createdate { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string UnenrolledDate { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(10)]
        public string enrolleddate { get; set; }
    }
}
