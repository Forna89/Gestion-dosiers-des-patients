using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_dossier_patient.models;

namespace gestion_dossier_patient.Pages_Prescriptions
{
    public class DetailsModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public DetailsModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

      public Prescription Prescription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.prescription == null)
            {
                return NotFound();
            }

            var prescription = await _context.prescription.FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }
            else 
            {
                Prescription = prescription;
            }
            return Page();
        }
    }
}
