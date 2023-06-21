
using Belleza.Data.Context;
using System.Data.SqlClient;

namespace Belleza.Models.Entities
{
    public class ClientEntities
    {

        private readonly string connectionString = $"{ContextPath.connectionSQL}";

        public List<ClientesE> GetList()
        {
            List<ClientesE> customers = new List<ClientesE>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Clientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientesE customer = new ClientesE
                            {
                                ClienteID = (int)reader["ClienteID"],
                                Nombre = reader["Nombre"].ToString(),
                                Identificacion =(int)reader["Identificacion"]
                            };

                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        //public void AddCustomer(Customer customer)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = "INSERT INTO Customers (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Name", customer.Name);
        //            command.Parameters.AddWithValue("@Email", customer.Email);
        //            command.Parameters.AddWithValue("@Phone", customer.Phone);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void UpdateCustomer(Customer customer)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = "UPDATE Customers SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id = @Id";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Id", customer.Id);
        //            command.Parameters.AddWithValue("@Name", customer.Name);
        //            command.Parameters.AddWithValue("@Email", customer.Email);
        //            command.Parameters.AddWithValue("@Phone", customer.Phone);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void DeleteCustomer(int customerId)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = "DELETE FROM Customers WHERE Id = @Id";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Id", customerId);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
    }

}
