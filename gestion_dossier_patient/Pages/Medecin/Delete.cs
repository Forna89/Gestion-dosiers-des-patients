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
    public class Delete : PageModel
    {
        private readonly MedecinContext _context;
        [BindProperty]

        public Medecins med { get; set; }

        public Delete(MedecinContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int Id)
        {
            med = _context.medecin.ToList().FirstOrDefault(p => p.Id == Id);

            if (med == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (med == null)
            {
                return RedirectToPage("./Index");
            }

            _context.Remove(med);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}