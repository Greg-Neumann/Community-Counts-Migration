namespace CC_Data_Migr.Models.ccoutput
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccmigr.attendance")]
    public partial class attendance
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string idattendance { get; set; }

        [Required]
        [StringLength(45)]
        public string resource { get; set; }

        [Required]
        [StringLength(45)]
        public string activity { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(6)]
        public string idclient { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(10)]
        public string sessiondate { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(8)]
        public string sessiontime { get; set; }

        [Column(TypeName = "char")]
        [StringLength(2)]
        public string attendedcount { get; set; }

        [Column(TypeName = "char")]
        [StringLength(8)]
        public string attendedtime { get; set; }

        [Column(TypeName = "char")]
        [StringLength(8)]
        public string signintime { get; set; }

        [Column(TypeName = "char")]
        [StringLength(8)]
        public string signouttime { get; set; }
    }
}
