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
    public class IndexModel : PageModel
    {
        private readonly gestion_dossier_patient.models.MedecinContext _context;

        public IndexModel(gestion_dossier_patient.models.MedecinContext context)
        {
            _context = context;
        }

        public IList<Dossier_patient> Dossier_patient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.dossier_patient != null)
            {
                Dossier_patient = await _context.dossier_patient.ToListAsync();
            }
        }
    }
}
