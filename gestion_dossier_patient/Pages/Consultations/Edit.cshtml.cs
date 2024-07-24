using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_dossier_patient.models;

namespace gestion_dossier_patient.Pages_Consultations
{
    public class EditModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public EditModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultation Consultation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.consultation == null)
            {
                return NotFound();
            }

            var consultation =  await _context.consultation.FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }
            Consultation = consultation;
           ViewData["medecinId"] = new SelectList(_context.medecin, "Id", "Fullname_medecin");
           ViewData["patientCode"] = new SelectList(_context.dossier_patient, "Code", "Fullname_patient");
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

            _context.Attach(Consultation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(Consultation.Id))
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

        private bool ConsultationExists(int id)
        {
          return _context.consultation.Any(e => e.Id == id);
        }
    }
}
