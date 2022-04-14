using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hastane.Models
{
    public class Duyuru
    {
        public int No { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public string Ozet { get; set; }
        public DateTime YayinTarihi { get; set; }
    }
}