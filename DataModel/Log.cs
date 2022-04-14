

namespace DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Log")]
    public partial class Log
    {
        [Key]
        public int No { get; set; }
        public DateTime Tarih { get; set; }
        public string Parametre { get; set; }
        public string MetotAdi { get; set; }
        public string IP { get; set; }
        public string Tarayici { get; set; }
        public int TabloNumara { get; set; }
    }
}
