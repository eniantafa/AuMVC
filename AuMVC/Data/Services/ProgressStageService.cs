using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;

namespace AuMVC.Data.Services
{
    public class ProgressStageService:IProgressStageService
    {

        private AppDbContext _context;
        public ProgressStageService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProgressStage> allProgressStages()
        {
            return _context.ProgressStages.ToList();
        }





        public void CreateProgressStage(ProgressStageViewModel viewModel)
        {
            ProgressStage progressStage = new ProgressStage()
            {

                Stage = viewModel.Stage,
                Value = viewModel.Value,
                DateCompleted = DateTime.Now,
                CompletedBy = viewModel.CompletedBy,
                DateApproved = DateTime.Now.AddMonths(3),
                ApprovedBy = viewModel.ApprovedBy,
                PaymentStatus = viewModel.PaymentStatus,
                DatePaid = DateTime.Now,
                SiteId = viewModel.SiteId

            };

            _context.ProgressStages.Add(progressStage);
            _context.SaveChanges();
        }

        public void Delete(int progressStageId)
        {
            ProgressStage progressStage = _context.ProgressStages.Where(n => n.Id == progressStageId).FirstOrDefault();
            _context.ProgressStages.Remove(progressStage);
            _context.SaveChanges();
        }

        public bool Exists(int progressStageId)
        {
            return _context.ProgressStages.Any(n => n.Id == progressStageId);
        }

        public ProgressStage GetProgressStageById(int progressStageId)
        {
            return _context.ProgressStages.Where(n => n.Id == progressStageId).FirstOrDefault();
        }

        

        public void UpdateProgressStage(ProgressStage newprogressStage)
        {
            ProgressStage oldProgressStage = _context.ProgressStages.Where(n => n.Id == newprogressStage.Id).FirstOrDefault();
            oldProgressStage.Stage = newprogressStage.Stage;
            oldProgressStage.Value = newprogressStage.Value;
            oldProgressStage.DateCompleted = newprogressStage.DateCompleted;
            oldProgressStage.DateApproved = newprogressStage.DateApproved;
            oldProgressStage.ApprovedBy = newprogressStage.ApprovedBy;
            oldProgressStage.PaymentStatus = newprogressStage.PaymentStatus;
            oldProgressStage.DatePaid = newprogressStage.DatePaid;

            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();
        }
    }
}
