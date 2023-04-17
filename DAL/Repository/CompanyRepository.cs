using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class CompanyRepository : Database, IReopsitory<Company, int, bool>
    {
        public bool Add(Company entity)
        {
            Context.Companies.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var company = GetById(id);
            if (company == null) return false;
            Context.Companies.Remove(company);
            return Context.SaveChanges() > 0;
        }
        public List<Company> GetAll()
        {
            return Context.Companies.ToList();
        }

        public Company GetById(int id)
        {
            return Context.Companies.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(Company entity)
        {
            var company = GetById(entity.Id);
            if (company == null) return false;
            Context.Entry(company).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
