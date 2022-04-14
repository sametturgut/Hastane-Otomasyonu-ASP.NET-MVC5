using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Hastane.Controllers
{
    [Attribute.Loglama]
    public class RandevuController : Controller
    {
        [HttpGet]
        //[Attribute.Loglama]        
       public ActionResult RandevuEkle()
        {
            return View("RandevuSayfa");
        }

        [HttpPost]
        //[Attribute.Loglama]
        public ActionResult RandevuEkle(DataModel.Muayene yeniMuayene)
        {
            return View("RandevuSayfa");
        }
        
    }
}