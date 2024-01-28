using ForumIT.Models.DTO;
using ForumIT.Models.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumIT.Controllers
{
    public class UserAuController : Controller
    {
        private readonly IAuRepository authRepository;

        public UserAuController(IAuRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginDTO loginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginRequestDto);
            }
            var result = await authRepository.LoginAsync(loginRequestDto);
            if (result.StatusCode == 1)
            {
                //tạo session login time lấy giờ đăng nhập htai
                HttpContext.Session.SetString("LoginTime",DateTime.Now.ToString());
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }

        }

        public IActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// Register
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerRequestDto)
        {
            if (!ModelState.IsValid) { 
                return View(registerRequestDto); 
            }
            registerRequestDto.Role = "user";
            var result = await authRepository.RegisterAsync(registerRequestDto);
            if (result.StatusCode == 1)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                ModelState.AddModelError("UserName", "User Exit");
                //TempData["msg"] = result.Message;
                return View(registerRequestDto);
            }
            //TempData["msg"] = result.Message;
           // return View();
        }


        /// <summary>
        /// Register Admin
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> RegisterAdmin()
        {
            if (User.IsInRole("admin"))
            {
                RegisterDTO registerRequestDto = new RegisterDTO()
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Password = "Admin@123456"
                };
                registerRequestDto.Role = "admin";
                var result = await authRepository.RegisterAsync(registerRequestDto);

                return Ok(result);
            }
            return RedirectToAction("Error", "Home");
            
        }


        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Logout()
        {

            string loginTime = HttpContext.Session.GetString("LoginTime");

            DateTime loginTimeStr = DateTime.Parse(loginTime);
            //var duration = DateTime.Now - loginTimeStr;
            //tính lịch sử đăng nhập 
            TimeSpan duration = DateTime.Now - loginTimeStr;
            string durationString = duration.ToString(@"hh\:mm\:ss");
            HttpContext.Session.SetString("History", durationString);

            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("LoginTime");
            await authRepository.LogOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
