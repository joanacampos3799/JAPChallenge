using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JAPChallenge.Models
{
    public class VehicleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string license_plate {  get; set; }
        public short YearOfFabrication { get; set; }
        public string FuelType { get; set; }

 

    }
}
