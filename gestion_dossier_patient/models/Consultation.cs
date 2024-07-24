using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_dossier_patient.models
{
    public class Consultation
    {
        [Key]
        //[MaxLength(11)]
        public int Id { get; set; }

        [Required]
        public int medecinId { get; set; }

        public Medecins medecin { get; set; }


        [Required]
        [MaxLength(50)]
        public string patientCode { get; set; }
        public Dossier_patient patient { get; set; }
        [Required]
        public double? Poids { get; set; }
        [Required]
        public double? Hauteur { get; set; }
        [Required]

        public string Diagnostique { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_Consultation { get; set; }
    }
}