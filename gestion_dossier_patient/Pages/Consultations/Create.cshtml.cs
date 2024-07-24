using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using gestion_dossier_patient.models;

namespace gestion_dossier_patient.Pages_Consultations
{
    public class CreateModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public CreateModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["medecinId"] = new SelectList(_context.medecin, "Id", "Fullname_medecin");
        ViewData["patientCode"] = new SelectList(_context.dossier_patient, "Code", "Fullname_patient");
            return Page();
        }

        [BindProperty]
        public Consultation Consultation { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.consultation.Add(Consultation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
