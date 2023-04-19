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
    public class DeliveryStatusServices
    {
        public static List<DeliveryStatusDto> GetAllDeliveryStatuses()
        {
            var deliveryStatusRepository = DataAccessFactory.GetDeliveryStatusRepository();
            var deliveryStatuses = Mapper.Map(deliveryStatusRepository.GetAll(), new List<DeliveryStatusDto>());
            return deliveryStatuses;
        }

        public static DeliveryStatusDto GetdeliveryStatusById(int id)
        {
            var deliveryStatusRepository = DataAccessFactory.GetDeliveryStatusRepository();
            var deliveryStatus = Mapper.Map(deliveryStatusRepository.GetById(id), new DeliveryStatusDto());
            return deliveryStatus;
        }

        public static bool AdddeliveryStatus(DeliveryStatusDto deliverystatus)
        {
            var deliveryStatusRepository = DataAccessFactory.GetDeliveryStatusRepository();
            var deliveryStatusToAdd = Mapper.Map(deliverystatus, new DeliveryStatus());
            return deliveryStatusRepository.Add(deliveryStatusToAdd);
        }

        public static bool UpdatedeliveryStatus(DeliveryStatusDto deliveryStatus)
        {
            var deliveryStatusRepository = DataAccessFactory.GetDeliveryStatusRepository();
            var deliveryStatusToUpdate = Mapper.Map(deliveryStatus, new DeliveryStatus());
            return deliveryStatusRepository.Update(deliveryStatusToUpdate);
        }

        public static bool DeletedeliveryStatus(int id)
        {
            var deliveryStatusRepository = DataAccessFactory.GetDeliveryStatusRepository();
            return deliveryStatusRepository.Delete(id);
        }
    }
}

