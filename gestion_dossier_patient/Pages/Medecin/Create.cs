using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_dossier_patient.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace gestion_dossier_patient.Pages.Medecin
{
    public class Create : PageModel
    {
        private readonly MedecinContext _context;

        //rendre le propriete med disponible sur l'interface
        [BindProperty]

        public Medecins med { get; set; }
        public Create(MedecinContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.medecin.Add(med);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}