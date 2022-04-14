using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hastane.Controllers
{
    [Attribute.Loglama]
    public class HastaController : Controller
    {
        public string Selam()
        {
            return "Merhaba Bilecik";
        }

        public string Selam2()
        {
            return "<strong>Merhaba</strong> Arkadaşlar";
        }

        public string Selam3(string id)
        {
            return "Merhaba " + id;
        }

        public string Selam4(string BolumAdi)
        {
            return BolumAdi;
        }

        public ActionResult AnaSayfa()
        {
            return View("AnaSayfa");
        }

        public ActionResult Bootstrap()
        {
            return View("bootstrapTest");
        }

        public ActionResult Baslangic()
        {
            return View("Baslangic");
        }

        public ActionResult Duyuru1(int id)
        {
            ViewBag.DuyuruNumara = id;
            ViewBag.DuyuruMetin = "Burası view bag ile oluşturulan metindir";

            ViewData["KullaniciAdi"] = "İlker Furkan ŞAHİN";

            TempData["OturumNumara"] = 61;

            return View("duyuruDetay1");
        }

        public ActionResult Duyuru2(int id)
        {
            Models.Duyuru yeniDuyuru = new Models.Duyuru();
            yeniDuyuru.No = 61;
            yeniDuyuru.Baslik = "Uzaktan Eğitim Sistemi Duyurusu";
            yeniDuyuru.YayinTarihi = DateTime.Now;
            yeniDuyuru.Metin = "Uzaktane eğitim açıldı. derseler girebilirsiniz";

            ViewBag.Duyuru = yeniDuyuru;

            return View("duyuruDetay2");
        }

        public ActionResult Duyuru3(int id)
        {
            Models.Duyuru yeniDuyuru = new Models.Duyuru();
            yeniDuyuru.No = 61;
            yeniDuyuru.Baslik = "Uzaktan Eğitim Sistemi Duyurusu";
            yeniDuyuru.YayinTarihi = DateTime.Now;
            yeniDuyuru.Metin = "Uzaktane eğitim açıldı. derseler girebilirsiniz";


            return View("duyuruDetay3",yeniDuyuru);
        }

        public ActionResult DuyuruListe()
        {
            List<Models.Duyuru> liste = new List<Models.Duyuru>();
            liste.Add(new Models.Duyuru
            {
                Baslik = "Uzaktan Eğitim Başlıyor",
                YayinTarihi = DateTime.Now,
                Ozet = "Web adreslerinden canlı derseler erişilebilir"
            });

            Models.Duyuru duyuru1 = new Models.Duyuru();
            duyuru1.Baslik = "Sınavlara giremeyenler için duyuru";
            duyuru1.YayinTarihi = DateTime.Now;
            duyuru1.Ozet = "Sınava giremeyenler rapor almak zorundadır";

            liste.Add(duyuru1);

            Models.Duyuru duyuru2 = new Models.Duyuru();
            duyuru2.Baslik = "Derslere devam zorunluluğu vardır";
            duyuru2.YayinTarihi = DateTime.Now;
            duyuru2.Ozet = "Canlı derselere devam kontrol edilecektir. Devamsızlıktan kalma vardır";

            liste.Add(duyuru2);

            return View("DuyuruListe", liste);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View("duyuruEkle");
        }

        [HttpPost]
        public ActionResult DuyuruEkle(Models.Duyuru yeniDuyuru)
        {
            yeniDuyuru.No = 545;

            return View("duyuruEkle");
        }
    }
}

