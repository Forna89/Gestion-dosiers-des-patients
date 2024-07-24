using gestion_dossier_patient.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace gestion_dossier_patient.Pages_Dossier_patients
{
    public class DetailsModel : PageModel
    {
        private readonly MedecinContext _context;

        public DetailsModel(MedecinContext context)
        {
            _context = context;
        }

        public Dossier_patient Dossier_patient { get; set; }
        public bool IsConsulted { get; set; } // Propriété pour stocker le statut de la consultation

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dossier_patient = await _context.dossier_patient.FirstOrDefaultAsync(m => m.Code == id);

            if (Dossier_patient == null)
            {
                return NotFound();
            }

            // Vérifier si le patient a été consulté
            IsConsulted = await _context.consultation.AnyAsync(c => c.patientCode == id);

            return Page();
        }
    }
}
