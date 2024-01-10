using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Martin_AdventureWorks.Data;
using Martin_AdventureWorks.Models;
using Microsoft.Data.SqlClient;

namespace Martin_AdventureWorks.Services
{
    public class AdventureWorksService : IAdventureWorksService
    {
        private readonly string _connectionString;

        public List<MasterListModel> MasterListModels { get; set; } = new List<MasterListModel>();
        public PersonDetailsModel PersonDetailsModels { get; set; } = new PersonDetailsModel();

        public AdventureWorksService()
        {
            _connectionString = db.GetConnectionString();
        }

        public async Task GetMasterList()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MasterListOfNames", (SqlConnection)connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            MasterListModels.Add(new MasterListModel
                            {
                                ID = Convert.ToInt32(reader["BusinessEntityID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString()
                            });
                        }
                    }
                }
            }
        }

        public async Task<PersonDetailsModel> GetPersonDetails(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("PersonDetails", (SqlConnection)connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@SelectedID", id));

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            PersonDetailsModels = new PersonDetailsModel
                            {
                                ID = Convert.ToInt32(reader["BusinessEntityID"]),
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Title = reader["Title"].ToString(),
                                Suffix = reader["Suffix"].ToString(),
                                PersonType = reader["PersonType"].ToString(),
                                EmailPromotion = reader["EmailPromotion"].ToString(),
                                AdditionalContactInfo = reader["AdditionalContactInfo"].ToString()
                            };
                        }
                    }
                }
            }

            return PersonDetailsModels;
        }

    }
}
