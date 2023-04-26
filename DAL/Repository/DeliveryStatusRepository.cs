using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DeliveryStatusRepository : Database, IReopsitory<DeliveryStatus, int, bool>
    {
        public bool Add(DeliveryStatus entity)
        {
            Context.DeliveryStatuses.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var deliveryStatus = GetById(id);
            if (deliveryStatus == null) return false;
            Context.DeliveryStatuses.Remove(deliveryStatus);
            return Context.SaveChanges() > 0;
        }

        public List<DeliveryStatus> GetAll() => Context.DeliveryStatuses.ToList();
        public DeliveryStatus GetById(int id) => Context.DeliveryStatuses.FirstOrDefault(u => u.Id == id);

        public bool Update(DeliveryStatus entity)
        {
            var deliveryStatus = GetById(entity.Id);
            if (deliveryStatus == null) return false;
            Context.Entry(deliveryStatus).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
