namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HastaneModel : DbContext
    {
        public HastaneModel()
            : base("name=HastaneModel")
        {
        }

        public virtual DbSet<Bolum> Bolum { get; set; }
        public virtual DbSet<Doktor> Doktor { get; set; }
        public virtual DbSet<Hastalik> Hastalik { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Muayene> Muayene { get; set; }
        public virtual DbSet<RisSeviyesi> RisSeviyesi { get; set; }
        public virtual DbSet<Teshis> Teshis { get; set; }
        public virtual DbSet<Unvan> Unvan { get; set; }
        public virtual DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doktor>()
                .Property(e => e.Maas)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.TckimlikNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RisSeviyesi>()
                .HasMany(e => e.Hastalik)
                .WithOptional(e => e.RisSeviyesi)
                .HasForeignKey(e => e.RiskSeviyesiNo);
        }
    }
}
