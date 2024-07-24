using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_dossier_patient.models;

namespace gestion_dossier_patient.Pages_Dossier_patients
{
    public class EditModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public EditModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dossier_patient Dossier_patient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.dossier_patient == null)
            {
                return NotFound();
            }

            var dossier_patient =  await _context.dossier_patient.FirstOrDefaultAsync(m => m.Code == id);
            if (dossier_patient == null)
            {
                return NotFound();
            }
            Dossier_patient = dossier_patient;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dossier_patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dossier_patientExists(Dossier_patient.Code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Dossier_patientExists(string id)
        {
          return _context.dossier_patient.Any(e => e.Code == id);
        }
    }
}
