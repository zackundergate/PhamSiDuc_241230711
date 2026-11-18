using Microsoft.AspNetCore.Mvc;
using PhamSiDuc_241230711.Models;
using System.Diagnostics;

namespace PhamSiDuc_241230711.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var db = new QlnhaSachContext();
            var ds=db.Saches.Where(s=>s.Gia!=null && s.Gia>=100).ToList();
            return View(ds);
        }
        public IActionResult LocSach(int id)
        {
            var db=new QlnhaSachContext();
            if(id==0)
            {
                ViewBag.TieuDe = "Phạm Sĩ Đức";
                var ds=db.Saches.Where(s=>s.Gia!=null && s.Gia>=100).ToList();
                return PartialView("PhamSiDuc_MainContent", ds);

            }
            ViewBag.TieuDe = db.TheLoais.Find(id)?.TenTl;
            var dsTheoLoai = db.Saches.Where(s => s.MaTl == id).ToList();
            return PartialView("PhamSiDuc_MainContent", dsTheoLoai);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
