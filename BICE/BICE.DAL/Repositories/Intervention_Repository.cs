using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BICE.DAL;
using BICE.BLL;
using BICE.DAL.Repositories;

namespace BICE.DAL
{
    public class InterventionRepository : Repository<Intervention_DAL>
    {
        public override Intervention_DAL GetById(int id)
        {
            InitializeConnectionAndCommand();
            Command.CommandText = "SELECT Id, Denomination, Description, StartDate, EndDate FROM Interventions WHERE Id = @id";
            Command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = Command.ExecuteReader();
            Intervention_DAL intervention = null;

            // While reading from the SqlDataReader
            if (reader.Read())
            {
                intervention = new Intervention_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.IsDBNull(2) ? null : reader.GetString(2),
                    reader.GetDateTime(3),
                    reader.GetDateTime(4)
                );
            }
            List<Intervention_DAL> interventions = new List<Intervention_DAL>();
// While reading all interventions
            while (reader.Read())
            {
                interventions.Add(new Intervention_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.IsDBNull(2) ? null : reader.GetString(2),
                    reader.GetDateTime(3),
                    reader.GetDateTime(4)
                ));
            }


            CloseAndDisposeConnectionAndCommand();
            return intervention;
        }

        public override IEnumerable<Intervention_DAL> GetAll()
        {
            InitializeConnectionAndCommand();
            Command.CommandText = "SELECT Id, Denomination, Description, StartDate, EndDate FROM Interventions";

            SqlDataReader reader = Command.ExecuteReader();
            List<Intervention_DAL> interventions = new List<Intervention_DAL>();

            while (reader.Read())
            {
                interventions.Add(new Intervention_DAL
                {
                    Id = reader.GetInt32(0),
                    Denomination = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                    StartDate = reader.GetDateTime(3),
                    EndDate = reader.GetDateTime(4)
                });
            }

            CloseAndDisposeConnectionAndCommand();
            return interventions;
        }

        public override Intervention_DAL Insert(Intervention_DAL intervention)
        {
            InitializeConnectionAndCommand();
            Command.CommandText = @"INSERT INTO Interventions (Denomination, Description, StartDate, EndDate) 
                                    VALUES (@Denomination, @Description, @StartDate, @EndDate);
                                    SELECT SCOPE_IDENTITY();";

            Command.Parameters.AddWithValue("@Denomination", intervention.Denomination);
            Command.Parameters.AddWithValue("@Description", intervention.Description ?? (object)DBNull.Value);
            Command.Parameters.AddWithValue("@StartDate", intervention.StartDate);
            Command.Parameters.AddWithValue("@EndDate", intervention.EndDate);

            intervention.Id = Convert.ToInt32(Command.ExecuteScalar());
            CloseAndDisposeConnectionAndCommand();

            return intervention;
        }

        public override Intervention_DAL Update(Intervention_DAL intervention)
        {
            InitializeConnectionAndCommand();
            Command.CommandText = @"UPDATE Interventions 
                                    SET Denomination = @Denomination, Description = @Description, StartDate = @StartDate, EndDate = @EndDate
                                    WHERE Id = @Id";

            Command.Parameters.AddWithValue("@Id", intervention.Id);
            Command.Parameters.AddWithValue("@Denomination", intervention.Denomination);
            Command.Parameters.AddWithValue("@Description", intervention.Description ?? (object)DBNull.Value);
            Command.Parameters.AddWithValue("@StartDate", intervention.StartDate);
            Command.Parameters.AddWithValue("@EndDate", intervention.EndDate);

            Command.ExecuteNonQuery();
            CloseAndDisposeConnectionAndCommand();

            return intervention;
        }

        public override void Delete(Intervention_DAL intervention)
        {
            InitializeConnectionAndCommand();
            Command.CommandText = "DELETE FROM Interventions WHERE Id = @Id";
            Command.Parameters.AddWithValue("@Id", intervention.Id);

            Command.ExecuteNonQuery();
            CloseAndDisposeConnectionAndCommand();
        }
    }
}
