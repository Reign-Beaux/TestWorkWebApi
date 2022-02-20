using BackendTestWork.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BackendTestWork.Helpers
{
    public class StoreProcedures
    {
        private string connectionString = "Data Source = (localdb)\\mssqllocaldb; Initial Catalog = TestWork; Integrated Security = True";

        public async Task<List<PersonDTO>> GetPersons()
        {
            List<PersonDTO> person = new List<PersonDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PersonsAll", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        PersonDTO oPerson = new PersonDTO();
                        oPerson.Id = reader.GetInt32(0);
                        oPerson.Nombre = reader.GetString(1);
                        oPerson.Edad = reader.GetInt32(2);
                        oPerson.FechaNacimiento = reader.GetDateTime(3);
                        person.Add(oPerson);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            return person;
        }
        public async Task<ActionResult<PersonDTO>> FindPerson(int Id)
        {
            PersonDTO person = new PersonDTO();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"PersonsGet {Id}", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        PersonDTO oPerson = new PersonDTO();
                        oPerson.Id = reader.GetInt32(0);
                        oPerson.Nombre = reader.GetString(1);
                        oPerson.Edad = reader.GetInt32(2);
                        oPerson.FechaNacimiento = reader.GetDateTime(3);
                        person = oPerson;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            return person;
        }
    }
}
