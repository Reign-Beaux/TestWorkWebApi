using BackendTestWork.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BackendTestWork.Helpers
{
    public class SPHistoricPerson
    {
        private string connectionString = "Data Source = (localdb)\\mssqllocaldb; Initial Catalog = TestWork; Integrated Security = True";

        public async Task<ActionResult<List<HistoricPerson>>> GetHistoric(int personId)
        {
            List<HistoricPerson> historic = new List<HistoricPerson>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"GetHistoricPerson {personId}", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        HistoricPerson oHistoric = new HistoricPerson();
                        oHistoric.Id = reader.GetInt32(0);
                        oHistoric.FechaCambio = reader.GetDateTime(1);
                        oHistoric.PersonId = reader.GetInt32(2);
                        oHistoric.Nombre = reader.GetString(3);
                        oHistoric.Edad = reader.GetInt32(4);
                        oHistoric.FechaNacimiento = reader.GetDateTime(5);
                        historic.Add(oHistoric);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            return historic;
        }

        public void RestorePerson(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"RestoreHistoricPerson {Id}", connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
    }
}
