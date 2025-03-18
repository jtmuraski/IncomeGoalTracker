using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Models.Ceu;

namespace IncomeGoalTracker.Data.Repositories
{
    public class CertificateRepo : ICertificateRepo
    {
        // Fields
        private IDbConnectionFactory _conn;

        // Constructors
        public CertificateRepo(IDbConnectionFactory conn)
        {
            _conn = conn;
        }

        public async Task<int> AddCertificateAsync(Certificate certificate)
        {
            string query = @"INSERT INTO Certificate (Name, 
                                                      Abbreviation,
                                                      CeusRequired,
                                                      CeuDueDate,
                                                      CertificateTrainingMonths,
                                                      InProcess)
                                         VALUES(@Name,
                                                @Abbreviation,
                                                @CeusRequired,
                                                @CeuDueDate,
                                                @CertificateTrainingMonths,
                                                @InProcess);
                              SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, certificate);
            }
        }

        public async Task<bool> DeleteCertificateAsync(int id)
        {
            string query = @"DELETE Certificate WHERE Id = @Id";

            using(var connection = _conn.CreateConnection())
            {
                int affectedRows = await connection.ExecuteAsync(query, new {Id = id});
                return affectedRows > 0;
            }
        }

        public async Task<IEnumerable<Certificate>> GetActiveCertificatesAsync()
        {
            string query = "SELECT * FROM Certificate WHERE InProcess = 1;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QueryAsync<Certificate>(query);
            }
        }

        public async Task<IEnumerable<Certificate>> GetAllCertificatesAsync()
        {
            string query = @"SELECT * FROM Certificate;";

            using (var connection = _conn.CreateConnection())
            {
                return await connection.QueryAsync<Certificate>(query);
            }
        }

        public async Task<Certificate> GetCertificateById(int id)
        {
            string query = @"SELECT * FROM Certificate WHERE Id = @Id;";
            
            using(var connection = _conn.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Certificate>(query, new {Id = id});
            }
        }

        public async Task<IEnumerable<Certificate>> GetExpiringCertificatesAsync(int days)
        {
            string query = @"SELECT * FROM Certificate WHERE CeuDueDate <= DATEADD(day, @Days, GETDATE());";

            using(var connection = _conn.CreateConnection())
            {
                return await connection.QueryAsync<Certificate>(query, new {Days = days});
            }
        }

        public async Task<bool> UpdateCertificateAsync(Certificate certificate)
        {
            string query = @"UPDATE Certificate 
                                SET Name = @Name,
                                    Abbreviation = @Abbreviation,
                                    CeusRequired = @CeusRequired,
                                    CeuDueDate = @CeuDueDate,
                                    CertificateTrainingMonths = @CertificateTrainingMonths,
                                    InProcess = @InProcess
                                WHERE Id = @Id;";

            using (var connection = _conn.CreateConnection())
            {
                int rowsAffected =  await connection.ExecuteAsync(query, certificate);
                return rowsAffected > 0;
            }
        }
    }
}
