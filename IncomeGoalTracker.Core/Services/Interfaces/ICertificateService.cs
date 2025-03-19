using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models.Ceu;

namespace IncomeGoalTracker.Core.Services.Interfaces
{
    internal interface ICertificateService
    {
        Task<bool> AddCertificateAsync(Certificate certificate);
        Task<bool> DeleteCertificateAsync(int id);
        Task<IEnumerable<Certificate>> GetAllCertificatesAsync();
        Task<bool> UpdateCertificateAsync(Certificate certificate);
        Task<bool> GetActiveCertificatesAsync();

    }
}
