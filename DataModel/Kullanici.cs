namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Doktor = new HashSet<Doktor>();
            Muayene = new HashSet<Muayene>();
        }

        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(250)]
        public string Ad { get; set; }

        [Required]
        [StringLength(250)]
        public string Soyad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }

        public DateTime? KayitTarihi { get; set; }

        public bool? Cinsiyet { get; set; }

        [StringLength(11)]
        public string TckimlikNo { get; set; }

        [StringLength(10)]
        public string KanGrubu { get; set; }

        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        public string Parola { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doktor> Doktor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Muayene> Muayene { get; set; }
    }
}
