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
        void CreateSite(SiteViewModel viewModel);
        Site GetSiteById(int siteId);
        void UpdateSite(Site newSite);
        bool Exists(int siteId);
        void Delete(int siteId);
        

    }
}
