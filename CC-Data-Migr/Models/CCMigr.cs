namespace CC_Data_Migr.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CCMigr : DbContext
    {
        public CCMigr()
            : base("name=CCMigr")
        {
        }

        public virtual DbSet<activity> activities { get; set; }
        public virtual DbSet<attendance> attendances { get; set; }
        public virtual DbSet<casework> caseworks { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<need> needs { get; set; }
        public virtual DbSet<needsnote> needsnotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<activity>()
                .Property(e => e.idclient)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.activityname)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.createdate)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.UnenrolledDate)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.enrolleddate)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.idattendance)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.resource)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.activity)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.idclient)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.sessiondate)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.sessiontime)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.attendedcount)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.attendedtime)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.signintime)
                .IsUnicode(false);

            modelBuilder.Entity<attendance>()
                .Property(e => e.signouttime)
                .IsUnicode(false);

            modelBuilder.Entity<casework>()
                .Property(e => e.idcasework)
                .IsUnicode(false);

            modelBuilder.Entity<casework>()
                .Property(e => e.activity)
                .IsUnicode(false);

            modelBuilder.Entity<casework>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<casework>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<casework>()
                .Property(e => e.staff)
                .IsUnicode(false);

            modelBuilder.Entity<casework>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.idclient)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.idclientprev)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.regyear)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.housenumber)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.addressline1)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.addressline2)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.county)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.agerange)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.ethnicity)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.ethnicity_other)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.occupation)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.occupation_other)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.disability)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.benefits)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.travelmethod)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.hearofservices)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.hearofservices_other)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.changeddatetime)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.createddatetime)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.signedbyclient)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.firstlanguage)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.firstlanguageother)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.housingstatus)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.tenantstatus)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.armedservicescurrently)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.armedservicesprev)
                .IsUnicode(false);

            modelBuilder.Entity<need>()
                .Property(e => e.idneeds)
                .IsUnicode(false);

            modelBuilder.Entity<need>()
                .Property(e => e.idclient)
                .IsUnicode(false);

            modelBuilder.Entity<need>()
                .Property(e => e.needscategory)
                .IsUnicode(false);

            modelBuilder.Entity<needsnote>()
                .Property(e => e.idneeds)
                .IsUnicode(false);

            modelBuilder.Entity<needsnote>()
                .Property(e => e.idclient)
                .IsUnicode(false);

            modelBuilder.Entity<needsnote>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<needsnote>()
                .Property(e => e.notes)
                .IsUnicode(false);
        }
    }
}
