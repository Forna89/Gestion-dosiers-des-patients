using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_dossier_patient.models;

namespace gestion_dossier_patient.Pages_Dossier_patients
{
    public class DeleteModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public DeleteModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Dossier_patient Dossier_patient { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.dossier_patient == null)
            {
                return NotFound();
            }

            var dossier_patient = await _context.dossier_patient.FirstOrDefaultAsync(m => m.Code == id);

            if (dossier_patient == null)
            {
                return NotFound();
            }
            else 
            {
                Dossier_patient = dossier_patient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.dossier_patient == null)
            {
                return NotFound();
            }
            var dossier_patient = await _context.dossier_patient.FindAsync(id);

            if (dossier_patient != null)
            {
                Dossier_patient = dossier_patient;
                _context.dossier_patient.Remove(Dossier_patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
