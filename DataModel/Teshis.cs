namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teshis
    {
        [Key]
        public int No { get; set; }

        public int? MuayeneNo { get; set; }

        public int? HastalikNo { get; set; }

        public DateTime? Tarih { get; set; }

        public virtual Hastalik Hastalik { get; set; }

        public virtual Muayene Muayene { get; set; }
    }
}
