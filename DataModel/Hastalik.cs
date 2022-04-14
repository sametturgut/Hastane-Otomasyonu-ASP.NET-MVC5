namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hastalik")]
    public partial class Hastalik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hastalik()
        {
            Teshis = new HashSet<Teshis>();
        }

        [Key]
        public int No { get; set; }

        public string Ad { get; set; }

        [StringLength(10)]
        public string KisaAd { get; set; }

        [StringLength(10)]
        public string Kodu { get; set; }

        public int? RiskSeviyesiNo { get; set; }

        public virtual RisSeviyesi RisSeviyesi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teshis> Teshis { get; set; }
    }
}
