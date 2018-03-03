using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;

namespace AuMVC.Data.Services
{
    public class VariationService : IVariationService
    {

        private AppDbContext _context;
        public VariationService(AppDbContext context)
        {
            _context = context;
        }


        public List<Variation> allVariations()
        {
            return _context.Variations.ToList();
        }

        public void CreateVariation(VariationViewModel viewModel)
        {

            Variation variation = new Variation()
            {

                VariationCode = viewModel.VariationCode,
                DateReleased = DateTime.Now,
                Contract = viewModel.Contract,
                Location = viewModel.Location,
                Description = viewModel.Description,
                Comment = viewModel.Comment,
                Price = viewModel.Price,
                EOT = viewModel.EOT,
                Status = viewModel.Status,
                Claimed = viewModel.Claimed,
                Paid = viewModel.Paid,
                PaymentDate = DateTime.Now,
                SiteId= viewModel.SiteId
                

            };

            _context.Variations.Add(variation);
            _context.SaveChanges();

        }

        public void Delete(int variationId)
        {
           Variation variation = _context.Variations.Where(n => n.Id == variationId).FirstOrDefault();
            _context.Variations.Remove(variation);
            _context.SaveChanges();
        }


        public bool Exists(int variationId)
        {
            return _context.Variations.Any(n => n.Id == variationId);
        }


        public Variation GetVariationById(int variationId)
        {
            return _context.Variations.Where(n => n.Id == variationId).FirstOrDefault();
        }


        public void UpdateVariation(Variation newVariation)
        {
            Variation oldVariation = _context.Variations.Where(n => n.Id == newVariation.Id).FirstOrDefault();
            oldVariation.VariationCode = newVariation.VariationCode;
            oldVariation.DateReleased = newVariation.DateReleased;
            oldVariation.Contract = newVariation.Contract;
            oldVariation.Location = newVariation.Location;
            oldVariation.Description = newVariation.Description;
            oldVariation.Comment = newVariation.Comment;
            oldVariation.Price = newVariation.Price;
            oldVariation.EOT = newVariation.EOT;
            oldVariation.Status = newVariation.Status;
            oldVariation.Claimed = newVariation.Claimed;
            oldVariation.Paid = newVariation.Paid;
            oldVariation.PaymentDate = newVariation.PaymentDate;
            //futen vlerat e tjera

            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();

        }
    }
}
