namespace CC_Data_Migr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ccmigr.client")]
    public partial class client
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string idclient { get; set; }

        [Column(TypeName = "char")]
        [StringLength(6)]
        public string idclientprev { get; set; }

        [Required]
        [StringLength(256)]
        public string firstname { get; set; }

        [Required]
        [StringLength(256)]
        public string lastname { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(8)]
        public string postcode { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string regyear { get; set; }

        [Required]
        [StringLength(256)]
        public string housenumber { get; set; }

        [Required]
        [StringLength(256)]
        public string addressline1 { get; set; }

        [StringLength(256)]
        public string addressline2 { get; set; }

        [Required]
        [StringLength(45)]
        public string city { get; set; }

        [StringLength(45)]
        public string county { get; set; }

        [StringLength(256)]
        public string phone { get; set; }

        [StringLength(256)]
        public string email { get; set; }

        [Required]
        [StringLength(45)]
        public string gender { get; set; }

        [Required]
        [StringLength(45)]
        public string agerange { get; set; }

        [Required]
        [StringLength(45)]
        public string ethnicity { get; set; }

        [Column("ethnicity-other")]
        [StringLength(45)]
        public string ethnicity_other { get; set; }

        [Required]
        [StringLength(60)]
        public string occupation { get; set; }

        [Column("occupation-other")]
        [StringLength(60)]
        public string occupation_other { get; set; }

        [Required]
        [StringLength(45)]
        public string disability { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string benefits { get; set; }

        [Required]
        [StringLength(45)]
        public string travelmethod { get; set; }

        [Required]
        [StringLength(45)]
        public string hearofservices { get; set; }

        [Column("hearofservices-other")]
        [StringLength(45)]
        public string hearofservices_other { get; set; }

        [Column(TypeName = "char")]
        [StringLength(19)]
        public string changeddatetime { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(19)]
        public string createddatetime { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string signedbyclient { get; set; }

        [Required]
        [StringLength(45)]
        public string firstlanguage { get; set; }

        [StringLength(45)]
        public string firstlanguageother { get; set; }

        [Required]
        [StringLength(45)]
        public string housingstatus { get; set; }

        [StringLength(45)]
        public string tenantstatus { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string armedservicescurrently { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string armedservicesprev { get; set; }
    }
}
