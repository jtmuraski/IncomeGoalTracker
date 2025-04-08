using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Mappers
{
    public static class ClassCeuMapper
    {
        public static ClassCeuView MapToView(ClassCeu classCeu)
        {
            return new ClassCeuView()
            {
                Id = classCeu.Id,
                CertificateId = classCeu.CertificateId,
                CeuHours = classCeu.CeuHours
            };
        }

        public static ClassCeu MapToModel(ClassCeuView classCeuView)
        {
            return new ClassCeu()
            {
                Id = classCeuView.Id,
                CertificateId = classCeuView.CertificateId,
                CeuHours = classCeuView.CeuHours
            };
        }
    }
}
