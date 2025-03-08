using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Interfaces
{
    public interface ICertificateRepo
    {
        // Basic Operations
        Task<IEnumerable<Certificate>> GetAllCertificatesAsync();
        Task<Certificate> GetCertificateById(int id);
        Task<int> AddCertificateAsync(Certificate certificate);
        Task<bool> UpdateCertificateAsync(Certificate certificate);
        Task<bool> DeleteCertificateAsync(int id);

        // Additional Operations
        Task<IEnumerable<Certificate>> GetActiveCertificatesAsync();
        Task<IEnumerable<Certificate>> GetExpiringCertificatesAsync(int days);
    }
}
