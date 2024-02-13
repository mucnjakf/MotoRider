using System.Collections.Generic;
using System.Data.SqlClient;

namespace MotoRider.SOAP.Services
{
    public class MotorcycleService
    {
        public static IEnumerable<Motorcycle> GetMotorcycles()
        {
            string connectionString = "Server=localhost;Database=MotoRiderDb;User Id=sa;Password=SQL;";
            var motorcycles = new List<Motorcycle>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Motorcycles";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                motorcycles.Add(new Motorcycle
                                {
                                    Id = (int)reader["Id"],
                                    Make = reader["Make"].ToString(),
                                    Model = reader["Model"].ToString(),
                                    YearOfManufacture = (int)reader["YearOfManufacture"],
                                    Mileage = (int)reader["Mileage"],
                                    Price = (double)reader["Price"],
                                    AvailableForRent = (bool)reader["AvailableForRent"],
                                });
                            }
                        }
                    }
                }
            }

            return motorcycles;
        }
    }
}
