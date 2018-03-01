using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;

namespace AuMVC.Data.Services
{
    public class SiteService : ISiteService
    {
        private AppDbContext _context;
        public SiteService(AppDbContext context)
        {
            _context = context;
        }

        public List<Site> allSites()
        {
            return _context.Sites.ToList();
        }

        public void CreateSite(SiteViewModel viewModel)
        {

            Site site = new Site()
            {
                SiteNumber = viewModel.SiteNumber,
                ContractDate = DateTime.Now,
                HomeOwner = viewModel.HomeOwner,
                ContactNumber = viewModel.ContactNumber,
                ContactEmail = viewModel.ContactEmail,
                HouseType = viewModel.HouseType,
                ContractValueExGST = viewModel.ContractValueExGST,
                ContractValueIncGST = viewModel.ContractValueIncGST,
                PreContactEOT = viewModel.PreContactEOT,
                DOPCDate = DateTime.Now,
                TwelveMonthMaintenance = DateTime.Now.AddYears(1),
                Note = viewModel.Note
            };

            _context.Sites.Add(site);
            _context.SaveChanges();
        }

        public void Delete(int siteId)
        {
            Site site = _context.Sites.Where(n => n.Id == siteId).FirstOrDefault();
            _context.Sites.Remove(site);
            _context.SaveChanges();
        }

        public bool Exists(int siteId)
        {
            return _context.Sites.Any(n => n.Id == siteId);
        }

        public Site GetSiteById(int siteId)
        {
            return _context.Sites.Where(n => n.Id == siteId).FirstOrDefault();
        }

        public void UpdateSite(Site newSite)
        {
            Site oldSite = GetSiteById(newSite.Id);
            oldSite.HomeOwner = newSite.HomeOwner;
            oldSite.SiteNumber = newSite.SiteNumber;
            oldSite.ContractDate = newSite.ContractDate;
            oldSite.ContactNumber = newSite.ContactNumber;
            oldSite.ContactEmail = newSite.ContactEmail;
            oldSite.HouseType = newSite.HouseType;
            oldSite.ContractValueExGST = newSite.ContractValueExGST;
            oldSite.ContractValueIncGST = newSite.ContractValueIncGST;
            oldSite.PreContactEOT = newSite.PreContactEOT;
            oldSite.DOPCDate = newSite.DOPCDate;
            oldSite.TwelveMonthMaintenance = newSite.TwelveMonthMaintenance;
            oldSite.Note = newSite.Note;
            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();
        }
    }
}
