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
    public class PaymentMethodServices
    {
        public static List<PaymentMethodDto> GetAllPaymentMethods()
        {
            var paymentmethodRepository = DataAccessFactory.GetPaymentMethodRepository();
            var paymentmethods = Mapper.Map(paymentmethodRepository.GetAll(), new List<PaymentMethodDto>());
            return paymentmethods;
        }

        public static PaymentMethodDto GetpaymentmethodById(int id)
        {
            var paymentmethodRepository = DataAccessFactory.GetPaymentMethodRepository();
            var paymentmethod = Mapper.Map(paymentmethodRepository.GetById(id), new PaymentMethodDto());
            return paymentmethod;
        }

        public static bool Addpaymentmethod(PaymentMethodDto paymentmethod)
        {
            var paymentmethodRepository = DataAccessFactory.GetPaymentMethodRepository();
            var paymentmethodToAdd = Mapper.Map(paymentmethod, new PaymentMethod());
            return paymentmethodRepository.Add(paymentmethodToAdd);
        }

        public static bool Updatepaymentmethod(PaymentMethodDto paymentmethod)
        {
            var paymentmethodRepository = DataAccessFactory.GetPaymentMethodRepository();
            var paymentmethodToUpdate = Mapper.Map(paymentmethod, new PaymentMethod());
            return paymentmethodRepository.Update(paymentmethodToUpdate);
        }

        public static bool Deletepaymentmethod(int id)
        {
            var paymentmethodRepository = DataAccessFactory.GetPaymentMethodRepository();
            return paymentmethodRepository.Delete(id);
        }
    }
}

