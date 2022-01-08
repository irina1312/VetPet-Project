using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetPet.Models
{
    public class Review  //book category
    {
        public int ID { get; set; }
       
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele medicului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)] 
        public string Nume_medic { get; set; }

        [StringLength(150, MinimumLength = 5)] 
        public string Reviewmedic { get; set; }
        public ICollection<MedicReview> MedicReviews { get; set; }
    }
}
