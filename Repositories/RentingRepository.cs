using JAPChallenge.Models;
using JAPChallenge.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace JAPChallenge.Repositories
{
    public class RentingRepository : IRentingRepository
    {
        private readonly JapChallengeDbContext context;
        public RentingRepository(JapChallengeDbContext context)
        {
            this.context = context;
        }
        public void AddRenting(RentingModel renting)
        {

            if (renting.InitialDate.HasValue)
            {
                renting.InitialDate = renting.InitialDate.Value.Date;
            }

            if (renting.EndDate.HasValue)
            {
                renting.EndDate = renting.EndDate.Value.Date;
            }

            context.Renting.Add(renting);
            context.SaveChanges();


        }

        public IEnumerable<RentingModel> ListRentings()
        {
           
                return context.Renting.ToList();
            

        }
    }
}
