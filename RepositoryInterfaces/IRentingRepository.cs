using JAPChallenge.Models;

namespace JAPChallenge.RepositoryInterfaces
{
    public interface IRentingRepository
    {
        IEnumerable<RentingModel> ListRentings();
        void AddRenting(RentingModel renting);
    }
}
