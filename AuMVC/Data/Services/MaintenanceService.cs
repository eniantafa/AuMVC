using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;

namespace AuMVC.Data.Services
{
    public class MaintenanceService : IMaintenanceService
    {

        private AppDbContext _context;
        public MaintenanceService(AppDbContext context)
        {
            _context = context;
        }

        public List<Maintenance> allMaintenances()
        {
            return _context.Maintenances.ToList();
        }




        public void CreateMaintenance(MaintenanceViewModel viewModel)
        {

            Maintenance maintenance = new Maintenance()
            {
                IssueCode = viewModel.IssueCode,
                DateRaised = DateTime.Now,
                Category = viewModel.Category,
                Item = viewModel.Item,
                Priority = viewModel.Priority,
                Status = viewModel.Status,
                Note = viewModel.Note

            };

            _context.Maintenances.Add(maintenance);
            _context.SaveChanges();
        }




        public void Delete(int maintenanceId)
        {
             Maintenance maintenance = _context.Maintenances.Where(n => n.Id == maintenanceId).FirstOrDefault();
            _context.Maintenances.Remove(maintenance);
            _context.SaveChanges();
        }





        public bool Exists(int maintenanceId)
        {
            return _context.Maintenances.Any(n => n.Id == maintenanceId);
        }




        public Maintenance GetMaintenanceById(int maintenanceId)
        {
            return _context.Maintenances.Where(n => n.Id == maintenanceId).FirstOrDefault();
        }




        public void UpdateMaintenance(Maintenance newMaintenance)
        {
            Maintenance oldMaintenance = _context.Maintenances.Where(n => n.Id == newMaintenance.Id).FirstOrDefault();
            oldMaintenance.IssueCode = newMaintenance.IssueCode;
            oldMaintenance.DateRaised = newMaintenance.DateRaised;
            oldMaintenance.Item = newMaintenance.Item;
            oldMaintenance.Priority = newMaintenance.Priority;
            oldMaintenance.Status = newMaintenance.Status;
            oldMaintenance.Note = newMaintenance.Note;


            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();
        }
    }
}
