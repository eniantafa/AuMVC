using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Services
{
    public interface IMaintenanceService
    {
        List<Maintenance> allMaintenances();
        void CreateMaintenance(MaintenanceViewModel viewModel);
        Maintenance GetMaintenanceById(int maintenanceId);
        void UpdateMaintenance(Maintenance newMaintenance);
        bool Exists(int maintenanceId);
        void Delete(int maintenanceId);
    }
}
