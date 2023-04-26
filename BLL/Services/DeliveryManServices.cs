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
    public class DeliveryManServices
    {
        public static List<DeliveryManDto> GetAllDeliveryMen()
        {
            var deliveryManRepository = DataAccessFactory.GetDeliveryManRepository();
            var deliveryMen = Mapper.Map(deliveryManRepository.GetAll(), new List<DeliveryManDto>());
            return deliveryMen;
        }

        public static DeliveryManDto GetdeliveryManById(int id)
        {
            var deliverymenRepository = DataAccessFactory.GetDeliveryManRepository();
            var deliverymen = Mapper.Map(deliverymenRepository.GetById(id), new DeliveryManDto());
            return deliverymen;
        }

        public static bool Adddeliveryman(DeliveryManDto deliveryMan)
        {
            var deliverymanRepository = DataAccessFactory.GetDeliveryManRepository();
            var deliveryManToAdd = Mapper.Map(deliveryMan, new DeliveryMan());
            return deliverymanRepository.Add(deliveryManToAdd);
        }

        public static bool UpdatedeliveryMan(DeliveryManDto deliveryMan)
        {
            var deliveryManRepository = DataAccessFactory.GetDeliveryManRepository();
            var deliveryManToUpdate = Mapper.Map(deliveryMan, new DeliveryMan());
            return deliveryManRepository.Update(deliveryManToUpdate);
        }

        public static bool DeletedeliveryMan(int id)
        {
            var deliveryManRepository = DataAccessFactory.GetDeliveryManRepository();
            return deliveryManRepository.Delete(id);
        }
    }
    

}
