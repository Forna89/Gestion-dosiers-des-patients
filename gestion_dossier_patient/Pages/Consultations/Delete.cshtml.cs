using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_dossier_patient.models;

namespace gestion_dossier_patient.Pages_Consultations
{
    public class DeleteModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public DeleteModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Consultation Consultation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.consultation == null)
            {
                return NotFound();
            }

            var consultation = await _context.consultation.FirstOrDefaultAsync(m => m.Id == id);

            if (consultation == null)
            {
                return NotFound();
            }
            else 
            {
                Consultation = consultation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.consultation == null)
            {
                return NotFound();
            }
            var consultation = await _context.consultation.FindAsync(id);

            if (consultation != null)
            {
                Consultation = consultation;
                _context.consultation.Remove(Consultation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
