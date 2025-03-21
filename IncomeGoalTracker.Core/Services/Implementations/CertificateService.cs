using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Models.Ceu;
using IncomeGoalTracker.Core.Models.Mappers;
using IncomeGoalTracker.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Services.Implementations
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepo _certificateRepo;
        private readonly ILogger<CertificateService> _logger;

        public CertificateService(ICertificateRepo certificateRepo, ILogger<CertificateService> logger)
        {
            _certificateRepo = certificateRepo;
            _logger = logger;
        }

        public async Task<int> AddCertificateAsync(CertificateView certificate)
        {
            _logger.LogInformation($"Adding certificate: {certificate.Name}");
            Certificate cert = CertificateMapper.MapToModel(certificate);
            int certId = await _certificateRepo.AddCertificateAsync(cert);
            return certId;
        }

        public async Task<bool> DeleteCertificateAsync(int id)
        {
            return await _certificateRepo.DeleteCertificateAsync(id);
        }

        public async Task<IEnumerable<CertificateView>> GetActiveCertificatesAsync()
        {
            IEnumerable<Certificate> certificates = await _certificateRepo.GetActiveCertificatesAsync();
            List<CertificateView> certificateViews = new List<CertificateView>();
            foreach (Certificate cert in certificates)
            {
                certificateViews.Add(CertificateMapper.MapToView(cert));
            }
            return certificateViews;

        }

        public async Task<IEnumerable<CertificateView>> GetAllCertificatesAsync()
        {
            IEnumerable<Certificate> certificates = await _certificateRepo.GetAllCertificatesAsync();
            List<CertificateView> certificateViews = new List<CertificateView>();
            foreach(Certificate cert in certificates)
            {
                certificateViews.Add(CertificateMapper.MapToView(cert));
            }
            return certificateViews;
        }

        public async Task<bool> UpdateCertificateAsync(CertificateView certificate)
        {
            return await _certificateRepo.UpdateCertificateAsync(CertificateMapper.MapToModel(certificate));
        }
    }
}
