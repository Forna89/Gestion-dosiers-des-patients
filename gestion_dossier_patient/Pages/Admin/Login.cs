using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gestion_dossier_patient.Pages.Admin
{
    public class Login
    {
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        [StringLength(100, ErrorMessage = "Le {0} doit être au moins {2} et au max {1} caractères de long.", MinimumLength = 6)]
        public string Password { get; set; }


    }
}