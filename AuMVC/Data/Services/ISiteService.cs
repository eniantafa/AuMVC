using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Services
{
    public interface ISiteService
    {
        List<Site> allSites();
        void Delete(int siteId);
        bool Exists(int siteId);
        Site GetSiteById(int siteId);
        void UpdateSite(Site newSite);
        void CreateSite(SiteViewModel viewModel);
    }
}
