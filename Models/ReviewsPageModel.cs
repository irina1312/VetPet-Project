using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetPet.Data;


namespace VetPet.Models
{
    public class ReviewsPageModel : PageModel
    {
        public List<Stea> SteaList;
        public void PopulateStea(VetPetContext context, Programare programare)
        {
            var allReviews = context.Review;
            var MedicReviews = new HashSet<int>(programare.MedicReviews.Select(c => c.ReviewID)); //
            SteaList = new List<Stea>();
            foreach (var cat in allReviews)
            {
                SteaList.Add(new Stea
                {
                    ReviewID = cat.ID,
                    Numar_stele = cat.Reviewmedic,
                    Assigned =MedicReviews.Contains(cat.ID)
                });
            }
        }
        public void UpdateMedicReviews(VetPetContext context,
        string[] selectedReviews, Programare programareToUpdate)
        {
            if (selectedReviews == null)
            {
                programareToUpdate.MedicReviews = new List<MedicReview>();
                return;
            }
            var selectedReviewsHS = new HashSet<string>(selectedReviews);
            var MedicReviews = new HashSet<int>
            (programareToUpdate.MedicReviews.Select(c => c.Review.ID));
            foreach (var cat in context.Review)
            {
                if (selectedReviewsHS.Contains(cat.ID.ToString()))
                {
                    if (!MedicReviews.Contains(cat.ID))
                    {
                        programareToUpdate.MedicReviews.Add(
                        new MedicReview
                        {
                            ProgramareID = programareToUpdate.ID,
                            ReviewID = cat.ID
                        });
                    }
                }
                else
                {
                    if (MedicReviews.Contains(cat.ID))
                    {
                        MedicReview courseToRemove
                        = programareToUpdate
                        .MedicReviews
                       .SingleOrDefault(i => i.ReviewID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
