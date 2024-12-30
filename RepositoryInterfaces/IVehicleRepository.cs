using JAPChallenge.Models;

namespace JAPChallenge.RepositoryInterfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<VehicleViewModel> ListVehicles();
        void AddVehicle(VehicleViewModel vehicle);
    }
}
