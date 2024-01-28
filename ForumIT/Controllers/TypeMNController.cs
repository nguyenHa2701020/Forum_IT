using ForumIT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ForumIT.Controllers
{
    [Authorize(Roles = "admin")]
    public class TypeMNController : Controller
    {
        ForumITContext db = new ForumITContext();
        public IActionResult ListLoaiDD(string filter)
        {
            ViewBag.Max = "ASC";
            ViewBag.Mess = "Tăng dần";
            if(filter != null)
            {
                if(filter == "ASC")
                {
                    ViewBag.Max = "DESC";
                    ViewBag.Mess = "Giảm dần";
                    var productst = db.TblLoaiDds.FromSqlRaw("EXEC SortTypeC2 @SortDirection", new SqlParameter("@SortDirection", filter)).ToList();
                    //ViewBag.search = filter;
                    return View(productst);
                }
                if (filter == "DESC")
                {
                    ViewBag.Max = "ASC";
                    ViewBag.Mess = "Tăng dần";
                    var productst = db.TblLoaiDds.FromSqlRaw("EXEC SortTypeC2 @SortDirection", new SqlParameter("@SortDirection", filter)).ToList();
                    //ViewBag.search = filter;
                    return View(productst);
                }
                int number;
                if(int.TryParse(filter, out number))
                {
                    var productst = db.TblLoaiDds.FromSqlRaw("EXEC TopType @SortDirection,@top", new SqlParameter("@SortDirection", ViewBag.Max), new SqlParameter("@top", number)).ToList();
                    return View(productst);
                }
                var products = db.TblLoaiDds.FromSqlRaw("EXEC SearchType @Key", new SqlParameter("@Key", filter)).ToList();
                ViewBag.search = filter;
                return View(products);
            }
            List<TblLoaiDd> lst = db.TblLoaiDds.ToList();
            ViewBag.option = lst;
            return View(lst);
        }

        public IActionResult CreateLoaiDD()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLoaiDD(TblLoaiDd loaiDd)
        {
            /*if (loaiDd.TenLoaiDd.ToString().Trim() == null)
            {
                ModelState.AddModelError("TenLoaiDd", "Đang để trống trường loại diễn đàn");
                return View();
            }
            else
            {*/
                //Prc use
                var idk = new SqlParameter("@tenloai", loaiDd.TenLoaiDd);

                db.Database.ExecuteSqlRaw("exec InsertType @tenloai",idk);

                //Frame use
                //db.TblLoaiDds.Add(loaiDd);
                //db.SaveChanges();
                return RedirectToAction("ListLoaiDD");
            //}
        }
        public IActionResult UpdateLoaiDD(int id)
        {
            
            TblLoaiDd model = db.TblLoaiDds.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateLoaiDD(TblLoaiDd model, int id)
        {
            //Prc use

            var idloai = new SqlParameter("@IdType", model.IdLoaiDd);
            var name = new SqlParameter("@nameType", model.TenLoaiDd);

            db.Database.ExecuteSqlRaw("exec UpdateType @IdType,@nameType", idloai, name);

            //Frame use
            /*TblLoaiDd ml = db.TblLoaiDds.Find(id);
            ml.TenLoaiDd = model.TenLoaiDd;
            db.SaveChanges();*/
            return RedirectToAction("ListLoaiDD");
        }
        public IActionResult DeleteLoaiDD(int id)
        {
            var idk = new SqlParameter("@idtype", id);

            db.Database.ExecuteSqlRaw("exec DelType @idtype", idk);

            return RedirectToAction("ListLoaiDD");
        }
        [HttpPost]
        public ActionResult SearchLoaiDD(string filter)
        {
            var products = db.TblLoaiDds.FromSqlRaw("EXEC SearchType @Key", new SqlParameter("@Key", filter)).ToList();


            //List<TblLoaiDd> lst = db.TblLoaiDds.Where(m => m.TenLoaiDd.ToLower().Contains(search.ToLower()) == true).ToList();
            //ViewBag.search = filter;
            return View(products);
        }

        public IActionResult DetailLoaiDD(int id)
        {
            TblLoaiDd model = db.TblLoaiDds.Find(id);
            return View(model);
        }
    }
}
