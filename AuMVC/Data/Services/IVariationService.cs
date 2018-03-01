using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Services
{
    public interface IVariationService
    {
        List<Variation> allVariations();
        void CreateVariation(VariationViewModel viewModel);
        Variation GetVariationById(int variationId);
        void UpdateVariation(Variation newVariation);
        bool Exists(int variationId);
        void Delete(int variationId);
    }
}
