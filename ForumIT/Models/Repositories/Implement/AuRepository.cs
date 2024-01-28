﻿
using ForumIT.Models.Domain;
using ForumIT.Models.DTO;
using ForumIT.Models.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ForumIT.Models.Repositories.Implement
{
    public class AuRepository : IAuRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuRepository(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<Status> LoginAsync(LoginDTO loginRequestDto)
        {
            var status = new Status();
            //tìm name đã tồn tại chưa
            var user = await userManager.FindByNameAsync(loginRequestDto.UserName);

            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid UserName";
                return status;
            }

            //Match Password
            if (!await userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, loginRequestDto.Password, false, false);

            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                //khẳng định username để thêm quyền vào bảng quyền
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Logged in successfully";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User is locked out";
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on logging in";
            }

            return status;
        }

        public async Task LogOutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> RegisterAsync(RegisterDTO registerRequestDto)
        {
            var status = new Status();
            var userExists = await userManager.FindByNameAsync(registerRequestDto.UserName);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already exist!";
                return status;
            }
            User user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registerRequestDto.Email,
                UserName = registerRequestDto.UserName,
                FirstName = registerRequestDto.FirstName,
                LastName = registerRequestDto.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var result = await userManager.CreateAsync(user, registerRequestDto.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return status;
            }


            //RoleManager
            //nếu chưa có tên quyeennf thì tạo tên quyyeefn 
            if (!await roleManager.RoleExistsAsync(registerRequestDto.Role))
                await roleManager.CreateAsync(new IdentityRole(registerRequestDto.Role));
            //nếu có tên quyền r thì gán user vs quyền đấy

            if (await roleManager.RoleExistsAsync(registerRequestDto.Role))
            {
                await userManager.AddToRoleAsync(user, registerRequestDto.Role);
            }

            status.StatusCode = 1;
            status.Message = "You have registered successfully";
            return status;
        }
    }
}
