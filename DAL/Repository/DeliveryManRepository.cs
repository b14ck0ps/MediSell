using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DeliveryManRepository : Database, IReopsitory<DeliveryMan, int, bool>
    {
        public bool Add(DeliveryMan entity)
        {
            Context.DeliveryMen.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var deliverymen = GetById(id);
            if (deliverymen == null) return false;
            Context.DeliveryMen.Remove(deliverymen);
            return Context.SaveChanges() > 0;
        }

        public bool Update(DeliveryMan entity)
        {
            var deliverymen = GetById(entity.Id);
            if (deliverymen == null) return false;
            Context.Entry(deliverymen).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
        public DeliveryMan GetById(int id) => Context.DeliveryMen.FirstOrDefault(u => u.Id == id);

        public List<DeliveryMan> GetAll() => Context.DeliveryMen.ToList();
    }
}
