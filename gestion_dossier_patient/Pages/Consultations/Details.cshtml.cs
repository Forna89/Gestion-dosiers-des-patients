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
    public class DetailsModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public DetailsModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

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
    }
}
