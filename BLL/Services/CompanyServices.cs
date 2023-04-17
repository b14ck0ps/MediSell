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
    public class CompanyServices
    {
        public static List<CompanyDto> GetAllCompany()
        {
            var CompanyRepository = DataAccessFactory.GetCompanyRepository();
            var companies = Mapper.Map(CompanyRepository.GetAll(), new List<CompanyDto>());
            return companies;
        }
        public static CompanyDto GetcompanyById(int id)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var company = Mapper.Map(companyRepository.GetById(id), new CompanyDto());
            return company;
        }
        public static bool Addcompany(CompanyDto company)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var companyToAdd = Mapper.Map(company, new Company());
            return companyRepository.Add(companyToAdd);
        }
        public static bool Updatecompany(CompanyDto company)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var companyToUpdate = Mapper.Map(company, new Company());
            return companyRepository.Update(companyToUpdate);
        }
        public static bool Deleteuser(int id)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            return companyRepository.Delete(id);
        }
    }
}
