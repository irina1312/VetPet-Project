using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPet.Models
{
    public class MedicReview
    {
        public int ID { get; set; }
        public int ProgramareID { get; set; }
        public Programare Programare { get; set; }
        public int ReviewID { get; set; }
        public Review Review { get; set; }
    }
}
