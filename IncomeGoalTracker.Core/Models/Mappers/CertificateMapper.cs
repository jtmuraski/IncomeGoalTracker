using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Mappers
{
    public static class CertificateMapper
    {
        public static CertificateView MapToView(Certificate certificate)
        {
            return new CertificateView
            {
                Id = certificate.Id,
                Name = certificate.Name,
                Abbreviation = certificate.Abbreviation,
                CeusRequired = certificate.CeusRequired,
                CeuDueDate = certificate.CeuDueDate,
                CertificateTrainingMonths = certificate.CertificateTrainingMonths,
                InProcess = certificate.InProcess,
                TrainingClasses = certificate.TrainingClasses.Select(tc => TrainingClassMapper.MapToView(tc)).ToList(),
                CeusEarned = certificate.CeusEarned,
                CeusRemaining = certificate.CeusRemaining
            };
        }

        public static Certificate MapToModel(CertificateView certificateView)
        {
            return new Certificate
            {
                Id = certificateView.Id,
                Name = certificateView.Name,
                Abbreviation = certificateView.Abbreviation,
                CeusRequired = certificateView.CeusRequired,
                CeuDueDate = certificateView.CeuDueDate,
                CertificateTrainingMonths = certificateView.CertificateTrainingMonths,
                InProcess = certificateView.InProcess,
                TrainingClasses = certificateView.TrainingClasses.Select(tc => TrainingClassMapper.MapToModel(tc)).ToList()
            };
        }
    }
}
