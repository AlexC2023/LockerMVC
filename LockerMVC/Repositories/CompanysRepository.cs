using LockerMVC.DataContext;
using LockerMVC.Models;
using LockerMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LockerMVC.Repositories
{
    public class CompanysRepository
    {
        private readonly LockerDataContext _context;

        public CompanysRepository(LockerDataContext context)
        {
            _context = context;
        }

        public DbSet<CompanyModel> GetCompanys()
        {
            return _context.Company;
        }

        public DbSet<CompanyModel> GetAll()
        {
            return _context.Company;
        }

        public void AddCompany(CompanyModel model)
        {
            //model.userid = Guid.NewGuid();
            _context.Company.Add(model);
            _context.SaveChanges();
        }

        public CompanyModel GetCompanyById(Guid id)
        {
            return _context.Company.FirstOrDefault(a => a.companyid == id);
        }

        public void UpdateCompany(Guid id, CompanyModel model)
        {
            _context.Company.Update(model);
            _context.SaveChanges();
        }

        public void DeleteCompanyById(CompanyModel model)
        {
            //var model = _context.User.FirstOrDefault(a => a.userid == id);
            _context.Company.Remove(model);
            _context.SaveChanges();
        }
        public CompanyUsergroupViewModel GetCompanyUsergroup(Guid id)
        {
            CompanyUsergroupViewModel modelUsergroupViewModel = new CompanyUsergroupViewModel();
            CompanyModel model = _context.Company.FirstOrDefault(x => x.companyid == id);
            if (model != null)
            {
                modelUsergroupViewModel.companyname = model.companyname;
                modelUsergroupViewModel.companyemail = model.companyemail;
                modelUsergroupViewModel.companycui = model.companycui;

                IQueryable<UsergroupModel> modelUsergroups = _context.Usergroup.Where(x => x.userid == id); //atunci cand dorim sa facem increase
                                                                                                            //la performanta daca ne e permis

                foreach (UsergroupModel dbUsergroup in modelUsergroups)
                {
                    modelUsergroupViewModel.Companys.Add(dbUsergroup);
                }

            }
            return modelUsergroupViewModel;
        }

    }
}