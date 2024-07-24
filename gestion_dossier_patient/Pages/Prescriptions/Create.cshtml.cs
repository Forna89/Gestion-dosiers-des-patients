using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using gestion_dossier_patient.models;

namespace gestion_dossier_patient.Pages_Prescriptions
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
        ViewData["consultationId"] = new SelectList(_context.consultation, "Id", "patientCode");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
