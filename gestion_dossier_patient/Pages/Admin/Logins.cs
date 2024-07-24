using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_dossier_patient.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace gestion_dossier_patient.Pages.Admin
{
    public class Logins : PageModel
    {
        private readonly SignInManager<AppUser> signIn;

        [BindProperty]
        
        public Login log { get; set; }

        public Logins(SignInManager<AppUser> signIn)
        {
            this.signIn = signIn;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(){
            var res = await signIn.PasswordSignInAsync(log.Username,log.Password,false,false);
            if(res.Succeeded){
                return RedirectToPage("../Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnGetLogOut(){
            //pour deconnecter
            await signIn.SignOutAsync();


            return RedirectToPage("/Admin/Logins");
        }

        
    }
}