namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doktor")]
    public partial class Doktor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doktor()
        {
            Muayene = new HashSet<Muayene>();
        }

        [Key]
        public int No { get; set; }

        [StringLength(32)]
        public string SicilNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Maas { get; set; }

        public DateTime? IseBaslamaTarihi { get; set; }

        public int? BolumNo { get; set; }

        public int? KullaniciNo { get; set; }

        public int? UnvanNo { get; set; }

        public virtual Bolum Bolum { get; set; }

        public virtual Unvan Unvan { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Muayene> Muayene { get; set; }
    }
}
