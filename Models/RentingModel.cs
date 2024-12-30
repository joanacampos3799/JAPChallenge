using System.ComponentModel.DataAnnotations;

namespace JAPChallenge.Models
{
    public class RentingModel
    {
        public long Id { get; set; }

        public long ClientId { get; set; }
        public ClientModel Client { get; set; } 

        public long VehicleId { get; set; }
        public VehicleModel Vehicle { get; set; }

        [DataType(DataType.Date)]
        public DateTime? InitialDate { get; set; } 


        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int InitialKms { get; set; }
    }
}
