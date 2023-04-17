using AutoMapper;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class ProfitServices
    {
        public static List<ProfitDto> GetAllProfits()
        {
            var ProfitRepository = DataAccessFactory.GetProfitRepository();
            var profit = Mapper.Map(ProfitRepository.GetAll(), new List<ProfitDto>());
            return profit;
        }
    }
}
