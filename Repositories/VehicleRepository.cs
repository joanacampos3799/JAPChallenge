using JAPChallenge.Models;
using JAPChallenge.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace JAPChallenge.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly JapChallengeDbContext context;
        public VehicleRepository(JapChallengeDbContext context)
        {
            this.context = context;
        }
        public void AddVehicle (VehicleViewModel vehicle)
        {
           
                if (context.Vehicle.Any(v => v.license_plate == vehicle.Registration))
                {
                    throw new Exception("License plate must be unique.");
                }

                VehicleModel model = new VehicleModel
                {
                    FuelType = vehicle.FuelType,
                    Model  = vehicle.Model,
                    Brand = vehicle.Brand,
                    license_plate = vehicle.Registration,
                    YearOfFabrication = vehicle.YearOfFabrication
                };
                context.Vehicle.Add (model);
                context.SaveChanges();
            

        }

        public IEnumerable<VehicleViewModel> ListVehicles()
        {
            
            List<VehicleViewModel> ret = new List<VehicleViewModel>();
                var currentDate = DateTime.Now;

                var vehicles = context.Vehicle.ToList();
                var rentingData = context.Renting.ToList();

                foreach (var vehicle in vehicles)
                {
                VehicleViewModel viewModel = new VehicleViewModel
                {
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Registration = vehicle.license_plate,
                    FuelType = vehicle.FuelType,
                    Id = vehicle.Id,
                    YearOfFabrication = vehicle.YearOfFabrication,
                };
                    var isRented = rentingData.Any(r =>
                        r.VehicleId == vehicle.Id &&
                        r.InitialDate <= currentDate &&
                        r.EndDate >= currentDate);

                    viewModel.Status = isRented ? "Rented" : "Available";
                ret.Add(viewModel);
                }

                return ret;
            }

        
    }
}
