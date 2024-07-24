
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
    public class Register : PageModel
    {

        private readonly UserManager<AppUser> user;

        [BindProperty]
        
        public User use { get; set; }
        

        public Register(UserManager<AppUser> user)
        {
           this.user = user;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(){
            AppUser appuser = new AppUser{UserName = use.Username};

            var res = await user.CreateAsync(appuser,use.Password);
            if(res.Succeeded){
                return RedirectToPage("/Admin/Logins");
            }

            return Page();
        }
    }
}