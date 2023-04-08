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
        public static bool Addcompany(CompanyDto company)
        {
            var companyRepository = DataAccessFactory.GetCompanyRepository();
            var companyToAdd = Mapper.Map(company, new Company());
            return companyRepository.Add(companyToAdd);
        }
    }
}
