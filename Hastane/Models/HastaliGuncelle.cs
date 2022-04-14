using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hastane.Models
{
    public class HastalikGuncelle
    {
        public DataModel.Hastalik Hastalik { get; set; }

        public List<DataModel.RisSeviyesi> RiskSeviyesiListe { get; set; }
    }
}