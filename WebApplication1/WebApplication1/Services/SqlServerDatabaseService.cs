using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{

    public interface IDatabaseService
    {
        IEnumerable<Animals> GetAnimals(string orderBy);
        int AddAnimal(Animals animals);
        int DeleteAnimal(int index);
        int UpdateAnimal(Animals animals, int index);
    }
    public class SqlServerDatabaseService : IDatabaseService
    {
        private IConfiguration _configuration;

        public SqlServerDatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Animals> GetAnimals(string orderBy)
        {
            var res = new List<Animals>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                if (String.IsNullOrEmpty(orderBy))
                    orderBy = "name ASC";
                else
                    orderBy += " ASC";
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Animals ORDER BY " + orderBy;

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    res.Add(new Animals
                    {
                        IdAnimal = (int)dr["IdAnimal"],
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    }) ;
                }
            }

            return res;
        }
        public int AddAnimal(Animals animals)
        {
            int rows = -1;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "INSERT INTO Animals(IdAnimal, Name, Description, Category, Area) " +
                                  "VALUES(@IdAnimal, @Name, @Description, @Category, @Area)";

                com.Parameters.AddWithValue("@IdAnimal", animals.IdAnimal);
                com.Parameters.AddWithValue("@Name", animals.Name);
                com.Parameters.AddWithValue("@Description", animals.Description);
                com.Parameters.AddWithValue("@Category", animals.Category);
                com.Parameters.AddWithValue("@Area", animals.Area);

                con.Open();
                rows = com.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteAnimal(int index)
        {
            int rows = -1;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "DELETE FROM Animals WHERE IdAnimal = @index";
                com.Parameters.AddWithValue("@index",index);
                con.Open();
                rows = com.ExecuteNonQuery();
            }
            return rows;
        }

        public int UpdateAnimal(Animals animals, int index)
        {
            int rows = -1;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "UPDATE Animals " +
                                  "SET     Name = @Name, " +
                                           "Description = @Description, " +
                                           "Category = @Category, " +
                                           "Area = @Area " +
                                  "WHERE IdAnimal = @index";

                com.Parameters.AddWithValue("@index", index);
                com.Parameters.AddWithValue("@Name", animals.Name);
                com.Parameters.AddWithValue("@Description", animals.Description);
                com.Parameters.AddWithValue("@Category", animals.Category);
                com.Parameters.AddWithValue("@Area", animals.Area);

                con.Open();
                rows = com.ExecuteNonQuery();
            }
            return rows;
        }
    }
}
