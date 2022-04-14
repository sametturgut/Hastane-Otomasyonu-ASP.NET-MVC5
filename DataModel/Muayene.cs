namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Muayene")]
    public partial class Muayene
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Muayene()
        {
            Teshis = new HashSet<Teshis>();
        }

        [Key]
        public int No { get; set; }

        public DateTime? Tarih { get; set; }

        public int? DoktorNo { get; set; }

        public int? KullaniciNo { get; set; }

        public int? BolumNo { get; set; }

        public virtual Bolum Bolum { get; set; }

        public virtual Doktor Doktor { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teshis> Teshis { get; set; }
    }
}
