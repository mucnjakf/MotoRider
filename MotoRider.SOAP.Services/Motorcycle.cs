namespace MotoRider.SOAP.Services
{
    public class Motorcycle
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int YearOfManufacture { get; set; }

        public int Mileage { get; set; }

        public double Price { get; set; }

        public bool AvailableForRent { get; set; }

        public override string ToString()
        {
            return $"\nID: {Id}\nName: {Make} {Model}\nYear of manufacture: {YearOfManufacture}\nMileage: {Mileage}\nPrice: ${Price}\n{IsAvailableForRent()}\n";
        }

        private string IsAvailableForRent()
        {
            return AvailableForRent == true ? "Available for rent" : "Not available for rent";
        }
    }
}