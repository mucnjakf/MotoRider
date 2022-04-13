using System;

namespace MotoRider.Shared.Models
{
    public class Rent
    {
        public int Id { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime RentedUntil { get; set; }

        public double Price { get; set; }

        public bool Completed { get; set; }

        public int MotorcycleId { get; set; }
        public virtual Motorcycle Motorcycle { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
