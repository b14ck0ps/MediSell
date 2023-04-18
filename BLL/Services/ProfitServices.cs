using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
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

        public static ProfitDto GetprofitById(int id)
        {
            var profitRepository = DataAccessFactory.GetProfitRepository();
            var profit = Mapper.Map(profitRepository.GetById(id), new ProfitDto());
            return profit;
        }

        public static bool Addprofit(ProfitDto profit)
        {
            var profitRepository = DataAccessFactory.GetProfitRepository();
            var profitToAdd = Mapper.Map(profit, new Profit());
            return profitRepository.Add(profitToAdd);
        }


        public static bool Updateprofit(ProfitDto profit)
        {
            var profitRepository = DataAccessFactory.GetProfitRepository();
            var profitToUpdate = Mapper.Map(profit, new Profit());
            return profitRepository.Update(profitToUpdate);
        }


        public static bool Deleteprofit(int id)
        {
            var profitRepository = DataAccessFactory.GetProfitRepository();
            return profitRepository.Delete(id);
        }




    }
}
