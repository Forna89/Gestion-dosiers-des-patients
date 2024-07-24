using gestion_dossier_patient.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace gestion_dossier_patient.Pages.Dossier_patients
{
    public class RecherchePatientModel : PageModel
    {
        private readonly MedecinContext _context;

        public RecherchePatientModel(MedecinContext context)
        {
            _context = context;
        }

        public List<Dossier_patient> Patients { get; set; }

        public IActionResult OnPost(string searchTerm)
        { 
            Patients = _context.dossier_patient
                            .Where(p => p.Code == searchTerm || p.Nom.Contains(searchTerm))
                            .ToList();

            return Page();
        }
    }
}
