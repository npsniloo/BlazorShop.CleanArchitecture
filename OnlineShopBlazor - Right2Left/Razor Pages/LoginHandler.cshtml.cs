
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using eShop.Domain.Enums;
using eShop.Application.UseCases.Common.Login;

namespace OnlineShopBlazor.Components.Pages
{
    public class LoginHandlerModel : PageModel
    {
        private readonly ILoginHandler _loginHandler;

        public LoginHandlerModel(ILoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }
        [BindProperty]
        public string? username { get; set; }
        [BindProperty]
        public string? password { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            username = Request.Query["Username"];
            password = Request.Query["Password"];

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return Redirect("/login");
            try
            {
                var response = await _loginHandler.ExecuteAsync(username, password);
                

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, response.Name),
                    new Claim(ClaimTypes.NameIdentifier, response.Id.ToString()),
                    new Claim(ClaimTypes.Email, response.Email),
                    new Claim(ClaimTypes.Role, response.IsAdmin? "admin":"user"),
                };
                var claimsIdentity = new ClaimsIdentity(claims, "MyCookiesAuth");

                //Sign in the user using the specifies authentication scheme ("MyCookieAuth")
                //This is the call that creates and sets the authentication cookie. 
                await HttpContext.SignInAsync("MyCookiesAuth", new ClaimsPrincipal(claimsIdentity));
                if (response.IsAdmin)
                    return Redirect("/Admin");
                else return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/login?message={Uri.EscapeDataString("نام کاربری یا رمز عبور اشتباه  است!")}");
            }
        }
    }
}
