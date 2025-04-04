using Dapper;
using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Data.Repositories
{
    public class ClassCeuRepo : IClassCeuRepo
    {
        private IDbConnectionFactory _conn;

        public ClassCeuRepo(IDbConnectionFactory conn)
        {
            _conn = conn;
        }
        public async Task<int> AddClassCeuAsync(ClassCeu classCeu)
        {
            string query = @"INSERT INTO ClassCeu (CertificateId,
                                                  TrainingClassId, 
                                                  CeuHours)
                                     VALUES (@CertificateId,
                                             @TrainingClassId,
                                             @CeuHours);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);";
            
            using(var connection = _conn.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, classCeu);
            }
        }

        public async Task<bool> DeleteClassCeuAsync(int id)
        {
            string query = @"DELETE FROM ClassCeu WHERE Id = @Id;";

            using (var connection = _conn.CreateConnection())
            {
                int rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<ClassCeu>> GetAllClassCeusAsync()
        {
            string query = @"SELECT * FROM ClassCeu;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QueryAsync<ClassCeu>(query);
            }
        }

        public async Task<ClassCeu> GetClassCeuByIdAsync(int id)
        {
            string query = @"SELECT * FROM ClassCeu WHERE Id = @Id;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<ClassCeu>(query, new {Id = id});
            }
        }

        public async Task<IEnumerable<ClassCeu>> GetClassCeuForCertificateAsync(int certificateId)
        {
            string query = @"SELECT * FROM ClassCeu WHERE CertificateId = @CertificateId;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QueryAsync<ClassCeu>(query, new { CertificateId = certificateId });
            }
        }

        public async Task<IEnumerable<ClassCeu>> GetClassCeuForTrainingClassAsync(int trainingClassId)
        {
            string query = @"SELECT * FROM ClassCeu WHERE TrainingClassId = @TrainingClassId;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QueryAsync<ClassCeu>(query, new {TrainingClassId = trainingClassId});
            }
        }

        public async Task<bool> UpdateClassCeuAsync(ClassCeu classCeu)
        {
            string query = @"UPDATE ClassCeu SET CertificateId = @CertificateId,
                                                 TrainingClassId = @TrainingClassId,
                                                 CeuHours = @CeuHours
                             WHERE Id = @Id;";

            using (var connection = _conn.CreateConnection())
            {
                int rowsAffected = await connection.ExecuteAsync(query, classCeu);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteTrainingClassCeus(int trainingClassId)
        {
            string query = @"DELETE FROM ClassCeu WHERE TrainingClassId = @ClassId;";

            using (var connection = _conn.CreateConnection())
            {
                int rowsAffected = await connection.ExecuteAsync(query, new { ClassId = trainingClassId });
                return rowsAffected > 0;
            }
        }
    }
}
