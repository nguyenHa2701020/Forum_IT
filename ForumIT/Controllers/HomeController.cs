using ForumIT.Models;
using ForumIT.Models.Domain;
using ForumIT.Models.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing.Printing;
using X.PagedList;

namespace ForumIT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page,string filter, int idd)
        {

          

            /*ViewBag.Set = "Max";
            ViewBag.Color = "green";
            ViewBag.Filters = "";
            ForumITContext db = new ForumITContext();
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            if (filter == null && idd == 0)
            {
                var lstMemberj = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt").OrderByDescending(x => x.Ngaydang).ToList();
                PagedList<TblBaiViet> lstkj = new PagedList<TblBaiViet>(lstMemberj, pageNumber, pageSize);
                return View(lstkj);
            }

            if (filter != null)
            {
                //Them
                if (filter == "OK")
                {
                    List<LuotBinhLuan> tb = new List<LuotBinhLuan>();
                    foreach (TblBaiViet baiViet in db.TblBaiViets)
                    {
                        LuotBinhLuan bk = new LuotBinhLuan();
                        bk.Id = baiViet.IdBaiViet;
                        bk.LuotBL = SoBLuan(baiViet.IdBaiViet);
                        tb.Add(bk);
                    }

                    List<LuotBinhLuan> tbb = tb.OrderByDescending(x => x.LuotBL).ToList();
                    List<TblBaiViet> tkkk = new List<TblBaiViet>();

                    foreach (LuotBinhLuan t in tbb)
                    {
                        TblBaiViet tviet = db.TblBaiViets.Find(t.Id);
                        tkkk.Add(tviet);

                    }
                    List<TblBaiViet> chot = tkkk.Where(x => x.TrangThai == "Duyệt").ToList();

                    //List<TblBaiViet> danhsachKhachHang = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                    PagedList<TblBaiViet> lstd = new PagedList<TblBaiViet>(chot, pageNumber, pageSize);

                    ViewBag.Filters = "OK";
                    return View(lstd);


                }

                if (filter == "oki")
                {
                    List<LuotBinhLuan> tb = new List<LuotBinhLuan>();
                    foreach (TblBaiViet baiViet in db.TblBaiViets)
                    {
                        LuotBinhLuan bk = new LuotBinhLuan();
                        bk.Id = baiViet.IdBaiViet;
                        bk.LuotBL = SoTuongTac(baiViet.IdBaiViet);
                        tb.Add(bk);
                    }

                    List<LuotBinhLuan> tbb = tb.OrderByDescending(x => x.LuotBL).ToList();
                    List<TblBaiViet> tkkk = new List<TblBaiViet>();

                    foreach (LuotBinhLuan t in tbb)
                    {
                        TblBaiViet tviet = db.TblBaiViets.Find(t.Id);
                        tkkk.Add(tviet);

                    }
                    List<TblBaiViet> chot = tkkk.Where(x => x.TrangThai == "Duyệt").ToList();
                    //List<TblBaiViet> danhsachKhachHang = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                    PagedList<TblBaiViet> lstd = new PagedList<TblBaiViet>(chot, pageNumber, pageSize);

                    ViewBag.Filters = "oki";

                    return View(lstd);
                }

                if (filter == "TruyCap")
                {
                    var lstMemberb = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt").OrderByDescending(x => x.TruyCap).ToList();
                    PagedList<TblBaiViet> lstkb = new PagedList<TblBaiViet>(lstMemberb, pageNumber, pageSize);

                    ViewBag.Filters = "TruyCap";
                    return View(lstkb);
                }
                if (filter == "Max")
                {
                    List<LuotBinhLuan> tb = new List<LuotBinhLuan>();
                    foreach (TblBaiViet baiViet in db.TblBaiViets)
                    {
                        LuotBinhLuan bk = new LuotBinhLuan();
                        bk.Id = baiViet.IdBaiViet;
                        bk.LuotBL = SoBLuan(baiViet.IdBaiViet);
                        tb.Add(bk);
                    }

                    //int max = tb.Max(x => x.LuotBL);
                    LuotBinhLuan btmax = tb.MaxBy(x => x.LuotBL);

                    List<TblBaiViet> tkkk = new List<TblBaiViet>();

                    foreach (TblBaiViet baiViet in db.TblBaiViets)
                    {
                        if (baiViet.IdBaiViet == btmax.Id)
                        {
                            tkkk.Add(baiViet);
                        }
                    }
                    List<TblBaiViet> chot = tkkk.Where(x => x.TrangThai == "Duyệt").ToList();
                    //List<TblBaiViet> danhsachKhachHang = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                    PagedList<TblBaiViet> lstd = new PagedList<TblBaiViet>(chot, pageNumber, pageSize);

                    ViewBag.Set = "Min";
                    ViewBag.Color = "red";
                    return View(lstd);
                }
                if (filter == "Min")
                {
                    List<LuotBinhLuan> tb = new List<LuotBinhLuan>();
                    foreach (TblBaiViet baiViet in db.TblBaiViets)
                    {
                        LuotBinhLuan bk = new LuotBinhLuan();
                        bk.Id = baiViet.IdBaiViet;
                        bk.LuotBL = SoBLuan(baiViet.IdBaiViet);
                        tb.Add(bk);
                    }

                    //int max = tb.Max(x => x.LuotBL);
                    LuotBinhLuan btmax = tb.MinBy(x => x.LuotBL);

                    List<TblBaiViet> tkkk = new List<TblBaiViet>();

                    foreach (TblBaiViet baiViet in db.TblBaiViets)
                    {
                        if (baiViet.IdBaiViet == btmax.Id)
                        {
                            tkkk.Add(baiViet);
                        }
                    }
                    List<TblBaiViet> chot = tkkk.Where(x => x.TrangThai == "Duyệt").ToList();
                    //List<TblBaiViet> danhsachKhachHang = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                    PagedList<TblBaiViet> lstd = new PagedList<TblBaiViet>(chot, pageNumber, pageSize);

                    ViewBag.Set = "Max";
                    ViewBag.Color = "green";
                    return View(lstd);
                }


                if (filter == "Top2")
                {
                    List<LuotBinhLuan> tb = new List<LuotBinhLuan>();
                    foreach (TblBaiViet baiViet in db.TblBaiViets)
                    {
                        LuotBinhLuan bk = new LuotBinhLuan();
                        bk.Id = baiViet.IdBaiViet;
                        bk.LuotBL = SoBLuan(baiViet.IdBaiViet);
                        tb.Add(bk);
                    }

                    List<LuotBinhLuan> tbb = tb.OrderByDescending(x => x.LuotBL).Take(2).ToList();

                    List<TblBaiViet> tkkk = new List<TblBaiViet>();

                    foreach (LuotBinhLuan t in tbb)
                    {
                        TblBaiViet tviet = db.TblBaiViets.Find(t.Id);
                        tkkk.Add(tviet);

                    }
                    List<TblBaiViet> chot = tkkk.Where(x => x.TrangThai == "Duyệt").ToList();
                    //List<TblBaiViet> danhsachKhachHang = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                    PagedList<TblBaiViet> lstd = new PagedList<TblBaiViet>(chot, pageNumber, pageSize);


                   
                    return View(lstd);
                }
                //End

                ViewBag.filter = filter;
                //tim kiem bai viet
                List<TblBaiViet> danhsachKhachHang = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                PagedList<TblBaiViet> lst = new PagedList<TblBaiViet>(danhsachKhachHang, pageNumber, pageSize);
                return View(lst);
            }

            string loginTime = HttpContext.Session.GetString("LoginTime");

            
            if(loginTime != null)
            {
                
                DateTime loginTimeStr = DateTime.Parse(loginTime);
                //var duration = DateTime.Now - loginTimeStr;

                TimeSpan duration = DateTime.Now - loginTimeStr;
                string durationString = duration.ToString(@"hh\:mm\:ss");
                //var durationInSeconds = duration.Seconds;


                //ViewBag.Duration ="Thời gian hoạt động:"+ durationString + "Phút";

                ViewBag.Time ="Bạn đăng nhập lúc: "+ loginTimeStr;

                ViewBag.Convv = loginTimeStr;
                
            }
            if (idd != null)
            {
                var lstMembert = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt" && x.IdLdd == idd).OrderByDescending(x => x.Ngaydang).ToList();
                PagedList<TblBaiViet> lstkt = new PagedList<TblBaiViet>(lstMembert, pageNumber, pageSize);
                return View(lstkt);
            }
            //int pageSize = 3;
            //int pageNumber = page == null || page < 0 ? 1 : page.Value;
            //hiện list
            var lstMember = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt").OrderByDescending(x=>x.Ngaydang).ToList();
            PagedList<TblBaiViet> lstk = new PagedList<TblBaiViet>(lstMember, pageNumber, pageSize);
            return View(lstk);*/
            ForumITContext db = new ForumITContext();

            if (filter == null && idd == 0)
            {
                var lstMemberj = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt").OrderByDescending(x => x.Ngaydang).ToList();

                return View(lstMemberj);
            }

           /* if (filter != null)
            {

                List<TblBaiViet> danhsachbv = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                List<TblBaiViet> chot = danhsachbv.Where(x => x.TrangThai == "Duyệt").ToList();

                return View(chot);

            }*/
            if (idd != null)
            {
                var lstMembert = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt" && x.IdLdd == idd).OrderByDescending(x => x.Ngaydang).ToList();
                return View(lstMembert);
            }
            var lstMember = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt").OrderByDescending(x => x.Ngaydang).ToList();
            return View(lstMember);
        }
        public IActionResult search(string filter)
        {
            ForumITContext db = new ForumITContext();
            List<TblBaiViet> bv = db.TblBaiViets.ToList();
            if (filter!=null)
            {
                List<TblLoaiDd> loai= db.TblLoaiDds.Where(x=>x.TenLoaiDd.Contains(filter)).ToList();
                List<TblBaiViet> bviet= new List<TblBaiViet>();
                foreach(TblLoaiDd dd in loai)
                {
                    foreach(TblBaiViet bvv in bv)
                    {
                        if(dd.IdLoaiDd==bvv.IdLdd)
                        {
                            bviet.Add(bvv);
                        }
                    }    
                }
                return View(bviet);
                


            }    
            
            return View(bv);
         
            }
        public IActionResult disable(int id)
        {
            TblDisable tblDisable = new TblDisable();
            tblDisable.FkT2 = id;
            tblDisable.Disable = true;
            tblDisable.Logtime = DateTime.Now;
            ForumITContext db = new ForumITContext();
            db.TblDisables.Add(tblDisable);
            db.SaveChanges();
            return RedirectToAction("search");
        }


        public IActionResult Error()
        {
            return View();
        }

        public IActionResult IndexComment(int? page, bool filter)
        {
            ForumITContext db = new ForumITContext();
            int pageSize = 2;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            if (filter == true)
            {
                List<LuotBinhLuan> tb=new List<LuotBinhLuan>();
                foreach(TblBaiViet baiViet in db.TblBaiViets)
                {
                    LuotBinhLuan bk = new LuotBinhLuan();
                    bk.Id = baiViet.IdBaiViet;
                    bk.LuotBL = SoBLuan(baiViet.IdBaiViet);
                    tb.Add(bk);
                }

                List<LuotBinhLuan> tbb=tb.OrderByDescending(x=>x.LuotBL).ToList();
                List<TblBaiViet> tkkk = new List<TblBaiViet>(); 

                foreach(LuotBinhLuan t in tbb)
                {
                    TblBaiViet tviet = db.TblBaiViets.Find(t.Id);
                    tkkk.Add(tviet);

                }
                //List<TblBaiViet> danhsachKhachHang = db.TblBaiViets.Where(m => m.Title.ToLower().Contains(filter.ToLower()) == true || m.NoiDung.Contains(filter.ToLower()) == true).OrderByDescending(x => x.Ngaydang).ToList();
                PagedList<TblBaiViet> lst = new PagedList<TblBaiViet>(tkkk, pageNumber, pageSize);
                

                return View(lst);


            }

            //int pageSize = 3;
            //int pageNumber = page == null || page < 0 ? 1 : page.Value;
            //hiện list
            var lstMember = db.TblBaiViets.Where(x => x.TrangThai == "Duyệt").OrderByDescending(x => x.Ngaydang).ToList();
            PagedList<TblBaiViet> lstk = new PagedList<TblBaiViet>(lstMember, pageNumber, pageSize);
            return View(lstk);
        }

        public int SoBLuan(int id)
        {
            ForumITContext db = new ForumITContext();
            int dem=0;
            List<TblBinhLuan>bl=db.TblBinhLuans.ToList();
            foreach(TblBinhLuan bll in bl)
            {
                if (bll.IdidBaiVietBl == id)
                {
                    dem++;
                }
            }
            return dem;

        }

        public int SoTuongTac(int idkd)
        {
            ForumITContext db = new ForumITContext();
            List<TblBinhLuan> lbt = db.TblBinhLuans.Where(x => x.IdidBaiVietBl == idkd).ToList();
            int countBL = lbt.Count();

            int countTL = 0;

            List<TblTraLoiBl> tll = new List<TblTraLoiBl>();

            List<TblTraLoiBl> tbltl = db.TblTraLoiBls.ToList();

            foreach (TblBinhLuan bll in lbt)
            {
                foreach (TblTraLoiBl tloi in tbltl)
                {
                    if (bll.IdBinhLuan == tloi.IdBluanTloi)
                    {
                        countTL++;
                    }
                }
            }

            return countTL+countBL;
        }


    }
}