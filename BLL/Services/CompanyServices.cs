using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class CompanyServices
    {
        public static List<CompanyDto> GetAllCompany()
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var companies = Mapper.Map(companyRepository.GetAll(), new List<CompanyDto>());
            return companies;
        }
        public static CompanyDto GetCompanyById(int id)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var company = Mapper.Map(companyRepository.GetById(id), new CompanyDto());
            return company;
        }
        public static bool AddCompany(CompanyDto company)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var companyToAdd = Mapper.Map(company, new Company());
            return companyRepository.Add(companyToAdd);
        }
        public static bool UpdateCompany(CompanyDto company)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var companyToUpdate = Mapper.Map(company, new Company());
            return companyRepository.Update(companyToUpdate);
        }
        public static bool DeleteCompany(int id)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            return companyRepository.Delete(id);
        }
    }
}
