using Dapper;
using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Data.Repositories
{
    public class TrainingClassRepo : ITrainingClassRepo
    {
        private IDbConnectionFactory _conn;

        public TrainingClassRepo(IDbConnectionFactory conn)
        {
            _conn = conn;
        }

        public async Task<int> AddTrainingClassAsync(TrainingClass trainingClass)
        {
           string query = @"INSERT INTO TrainingClass (Name,
                                                    Provider,
                                                    CeusEarned,
                                                    DateComplete,
                                                    CertificateLocation)
                                                    VALUES (@Name,
                                                            @Provider,
                                                            @CeusEarned,
                                                            @DateComplate,
                                                            @CertitificateLocation)
                                                    SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, trainingClass);
            }
        }

        public async Task<bool> DeleteTrainingClassAsync(int id)
        {
            string query = @"DELETE TrainingClass WHERE Id = @Id;";

            using (var connection = _conn.CreateConnection())
            {
               int affectedRows = await connection.ExecuteAsync(query, new {Id = id});
                return affectedRows > 0;
            }
        }

        public async Task<IEnumerable<TrainingClass>> GetAllTrainingClassesAsync()
        {
            string query = @"SELECT * FROM TrainingClass;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QueryAsync<TrainingClass>(query);
            }
        }

        public async Task<TrainingClass> GetTrainingClassByIdAsync(int id)
        {
            string query = @"SELECT * FROM TrainingClass WHERE Id = @Id;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TrainingClass>(query, new {Id = id});
            }
        }

        public async Task<bool> UpdateTrainingClassAsync(TrainingClass trainingClass)
        {
            string query = @"UPDATE TrainingClass SET Name = @Name,
                                                    Provider = @Provider,
                                                    CeusEarned = @CeusEarned,
                                                    DateComplete = @DateComplate,
                                                    CertificaterLocation = @CertitificateLocation
                                                    WHERE Id = @Id;";

            using (var connection = _conn.CreateConnection())
            {
                int affectedRows = await connection.ExecuteAsync(query, trainingClass);
                return affectedRows > 0;
            }
        }
    }
}
