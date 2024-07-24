using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gestion_dossier_patient.models
{
    public class Medecins
    {
        [Key] // Définir comme clé primaire
              //[MaxLength(11)] // Spécifier la longueur maximale
        public int Id { get; set; }
        [Required]
        [MaxLength(50)] // Spécifier la longueur maximale
        public string Nom { get; set; }
        [Required]
        [MaxLength(50)] // Spécifier la longueur maximale
        public string Prenom { get; set; }

        public string Fullname_medecin
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }


        [Required]
        [MaxLength(8)] // Spécifier la longueur maximale
        public string Sexe { get; set; }
        [Required]
        [MaxLength(20)] // Spécifier la longueur maximale
        public string Tel { get; set; }
        [Required]
        [MaxLength(100)] // Spécifier la longueur maximale
        public string Adresse { get; set; }
        [Required]
        [MaxLength(50)] // Spécifier la longueur maximale
        public string Email { get; set; }
        [Required]
        [MaxLength(50)] // Spécifier la longueur maximale
        public string Specialite { get; set; }
    }
}