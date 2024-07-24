using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_dossier_patient.models
{
    public class Dossier_patient
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]

        [MaxLength(50)]
        public string Nom { get; set; }
        [Required]

        [MaxLength(50)]
        public string Prenom { get; set; }


        public string Fullname_patient
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }


        [Required]
        [MaxLength(8)]
        public string Sexe { get; set; }
        [Required]
        [MaxLength(20)]
        public string Tel { get; set; }
        [Required]
        [MaxLength(100)]
        public string Adresse { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_Enregistrement { get; set; }
    }

}