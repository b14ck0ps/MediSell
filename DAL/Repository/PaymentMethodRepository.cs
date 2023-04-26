using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PaymentMethodRepository : Database, IReopsitory<PaymentMethod, int, bool>
    {
        public bool Add(PaymentMethod entity)
        {
            Context.PaymentMethods.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var payment = GetById(id);
            if (payment == null) return false;
            Context.PaymentMethods.Remove(payment);
            return Context.SaveChanges() > 0;
        }

        public PaymentMethod GetById(int id) => Context.PaymentMethods.FirstOrDefault(u => u.Id == id);

        public List<PaymentMethod> GetAll() => Context.PaymentMethods.ToList();

        public bool Update(PaymentMethod entity)
        {
            var payment = GetById(entity.Id);
            if (payment == null) return false;
            Context.Entry(payment).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
