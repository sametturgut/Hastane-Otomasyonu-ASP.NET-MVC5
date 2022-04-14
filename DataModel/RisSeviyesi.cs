namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RisSeviyesi")]
    public partial class RisSeviyesi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RisSeviyesi()
        {
            Hastalik = new HashSet<Hastalik>();
        }

        [Key]
        public int No { get; set; }

        public string Ad { get; set; }

        public int? RiskSiraNumarasi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hastalik> Hastalik { get; set; }
    }
}
