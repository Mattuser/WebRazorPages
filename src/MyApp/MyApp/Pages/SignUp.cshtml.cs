using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public SignUpRequest SignUpRequest { get; set; }
        public void OnGet()
        {
            ViewData["confirmation"] = $"FirstName ";
        }

       public void OnPost()
        {
            if(ModelState.IsValid)
            {
                string userName = SignUpRequest.UserName;
                string password = SignUpRequest.Password;
                string email = SignUpRequest.Email;
                ViewData["confirmation"] = $"{userName}, information will be sent to {email}";
            }
            else
            {
                ViewData["confirmation"] = ModelState.ErrorCount;
            }
           
           
        }
    }
}
