using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models.Ceu;

namespace IncomeGoalTracker.Core.Services.Interfaces
{
    public interface ICertificateService
    {
        public Task<int> AddCertificateAsync(CertificateView certificate);
        public Task<bool> DeleteCertificateAsync(int id);
        public Task<IEnumerable<CertificateView>> GetAllCertificatesAsync();
        public Task<bool> UpdateCertificateAsync(CertificateView certificate);
        public Task<IEnumerable<CertificateView>> GetActiveCertificatesAsync();

    }
}
