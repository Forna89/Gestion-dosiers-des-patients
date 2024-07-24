using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_dossier_patient.models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int consultationId { get; set; }
        public Consultation consultation { get; set; }
        [Required]
        public string Prescription_Text { get; set; }
    }
}