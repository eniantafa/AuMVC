using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Services
{
    public interface IProgressStageService
    {
        List<ProgressStage> allProgressStages();
        void CreateProgressStage(ProgressStageViewModel viewModel);
        ProgressStage GetProgressStageById(int progressStageId);
        void UpdateProgressStage(ProgressStage newprogressStage);
        bool Exists(int progressStageId);
        void Delete(int progressStageId);
    }
}
