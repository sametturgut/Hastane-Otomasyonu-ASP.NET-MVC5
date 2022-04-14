using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hastane.Controllers
{
    //[RoutePrefix("bilecik")]
    [Attribute.Loglama]
    public class UnvanController : Controller
    {
       public ActionResult UnvanListe()
        {
            DataModel.HastaneModel verimodel = new DataModel.HastaneModel();

            var liste = verimodel.Unvan.ToList();
            

            return View("UnvanListe", liste);
        }

        public ActionResult UnvanListe2()
        {
            //Lambda operatörü kullanarak kayıtları seçmek
            DataModel.HastaneModel model = new DataModel.HastaneModel();

            var liste = model.Unvan.ToList().Select(p => new DataModel.Unvan {No=p.No,Ad=p.Ad }).ToList();

            var filtreliListe = model.Unvan.Where(u => u.No > 2 && u.Doktor.Count > 1).ToList();

            return View("UnvanListe", liste);
        }

        public ActionResult UnvanListe3()
        {
            //Linq sorgulaması ile kayıtları seçmek
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var liste = (from u in model.Unvan
                         where u.No > 2
                        select new DataModel.Unvan
                        {
                            No=u.No,
                            Ad=u.Ad,
                            KisaAd=u.KisaAd
                        }                        
                        ).ToList();



            return View("UnvanListe", liste);
        }

        //[Route("Doktor/{DoktorNo:int=6}")]
        [Route("Doktor/{DoktorNo:int:min(1)}")]
       public ActionResult DoktorBilgi(int DoktorNo)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();

            var seciliDoktor = model.Doktor.FirstOrDefault(d=>d.No == DoktorNo);

            string ad = seciliDoktor.Kullanici.Ad;
            string unvan = seciliDoktor.Unvan.Ad;
            var muayeneListe = seciliDoktor.Muayene.ToList();




            return View("DoktorBilgi",seciliDoktor);

        }

        [HttpGet]
        public ActionResult UnvanEkle()
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var liste = model.Unvan.ToList();
            return View("UnvanEkle", liste);
        }

        [HttpPost]
        public ActionResult UnvanEkle(DataModel.Unvan yeniUnvan)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            model.Unvan.Add(yeniUnvan);
            model.SaveChanges();

            return RedirectToAction("UnvanEkle");//View("UnvanEkle");
        }

        [HttpPost]
        public ActionResult UnvanSil(int UnvanNo)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var silinecekUnvan = model.Unvan.FirstOrDefault(p => p.No == UnvanNo);
            model.Unvan.Remove(silinecekUnvan);
            model.SaveChanges();
            return RedirectToAction("UnvanEkle");
        }


        public ActionResult UnvanDoktorGetir(int UnvanNo)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var doktorListesi = model.Doktor.Where(p => p.UnvanNo == UnvanNo).ToList();

            return View("DoktorListesi",doktorListesi);
        }

        public ActionResult BolumDoktorGetir(int BolumNo, int UnvanNo)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var secilenBolum = model.Bolum.FirstOrDefault(b => b.No == BolumNo);
            var doktorListe = secilenBolum.Doktor.Where(bd => bd.UnvanNo == UnvanNo).ToList();

            return View("DoktorListesi", doktorListe);
        }

        [HttpGet]
        public ActionResult HastalikEkle()
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var liste = model.RisSeviyesi.ToList();

            return View("HastalikEkle",liste);
        }

        [HttpPost]
        public ActionResult HastalikEkle(DataModel.Hastalik yeniHastalik)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            model.Hastalik.Add(yeniHastalik);
            model.SaveChanges();

            //return View("HastalikEkle");
            return RedirectToAction("HastalikEkle");
        }

        public ActionResult HastalikListe()
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var liste = model.Hastalik.ToList();

            return View("HastalikListe", liste);
        }

        [HttpPost]
        public ActionResult HastalikSil(int HastalikNo)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var silinecekKayit = model.Hastalik.FirstOrDefault(p => p.No == HastalikNo);
            model.Hastalik.Remove(silinecekKayit);
            model.SaveChanges();

            return RedirectToAction("HastalikListe");

        }
        [HttpGet]
        public ActionResult HastalikGuncelle(int id)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var hastalik = model.Hastalik.FirstOrDefault(p => p.No == id);
            var riskSeviyesiListe = model.RisSeviyesi.ToList();

            Models.HastalikGuncelle guncellemeModel = new Models.HastalikGuncelle();
            guncellemeModel.Hastalik = hastalik;
            guncellemeModel.RiskSeviyesiListe = riskSeviyesiListe;

            return View("HastalikGuncelle",guncellemeModel);
        }

        [HttpPost]
        public ActionResult HastalikGuncelle(DataModel.Hastalik guncellenecekHastalik)
        {
            DataModel.HastaneModel model = new DataModel.HastaneModel();
            var hastalik = model.Hastalik.FirstOrDefault(p => p.No == guncellenecekHastalik.No);
            hastalik.Ad = guncellenecekHastalik.Ad;
            hastalik.KisaAd = guncellenecekHastalik.KisaAd;
            hastalik.RiskSeviyesiNo = guncellenecekHastalik.RiskSeviyesiNo;
            hastalik.Kodu = guncellenecekHastalik.Kodu;

            model.SaveChanges();
            return RedirectToAction("HastalikListe");
        }
    }
}