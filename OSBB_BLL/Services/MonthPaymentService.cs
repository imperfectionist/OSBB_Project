using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using OSBB_BLL.Models;
using OSBB_DAL.Models;
using OSBB_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Services
{
    public class MonthPaymentService : IGenericService<MonthPaymentDTO>
    {
        IGenericRepository<MonthPayment> monthPaymentRepository;
        readonly IMapper _mapper;

        public MonthPaymentService(IGenericRepository<MonthPayment> monthPaymentRepository)
        {
            this.monthPaymentRepository = monthPaymentRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<MonthPayment, MonthPaymentDTO>();
                cfg.CreateMap<MonthPaymentDTO, MonthPayment>();
            }).CreateMapper();
        }

        public MonthPaymentDTO AddOrUpdate(MonthPaymentDTO obj)
        {
            try
            {
                MonthPayment payment = _mapper.Map<MonthPayment>(obj);
                monthPaymentRepository.AddOrUpdate(payment);
                return _mapper.Map<MonthPaymentDTO>(payment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MonthPaymentDTO Delete(MonthPaymentDTO obj)
        {
            try
            {
                MonthPayment payment = _mapper.Map<MonthPayment>(obj);
                monthPaymentRepository.Delete(payment);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MonthPaymentDTO> FindBy(Expression<Func<MonthPaymentDTO, bool>> predicate)
        {
            try
            {
                var paymentPredicate = _mapper.Map<Expression<Func<MonthPayment, bool>>>(predicate);
                return monthPaymentRepository.FindBy(paymentPredicate).Select(p => _mapper.Map<MonthPaymentDTO>(p));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MonthPaymentDTO Get(int id)
        {
            try
            {
                return _mapper.Map<MonthPaymentDTO>(monthPaymentRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MonthPaymentDTO> GetAll()
        {
            try
            {
                return monthPaymentRepository.GetAll().Select(p => _mapper.Map<MonthPaymentDTO>(p));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
