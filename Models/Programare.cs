using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetPet.Models
{
    public class Programare
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        public string Nume_pacient { get; set; }
        
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele insotitorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)] 
        public string Nume_insotitor { get; set; }
       
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele Doctorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)] 
        public string Nume_doctor { get; set; }
        public DateTime Data_programarii { get; set;  }
        public ICollection<MedicReview> MedicReviews { get; set; }


    }
}
