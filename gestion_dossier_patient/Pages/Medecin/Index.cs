using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_dossier_patient.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace gestion_dossier_patient.Pages.Medecin
{
    public class Index : PageModel
    {
       private readonly MedecinContext _context;

       public List<Medecins> medecins{get; set;} = new List<Medecins>();
       
        public Index(MedecinContext context)
        {
          //initialiser le context
          _context = context;
        }


//onget pour initialiser les donnees pran donner nan espace de stockage lan voye li nan tableau dynamique
        //onpost pour envoyer des donnees
        public void OnGet()
        {
            medecins = _context.medecin.ToList();
        }
    }
}