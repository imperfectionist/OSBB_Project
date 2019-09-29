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
    public class MonthPaymentDetailService : IGenericService<MonthPaymentsDetailDTO>
    {
        IGenericRepository<MonthPaymentsDetail> paymentDetailRepository;
        readonly IMapper _mapper;

        public MonthPaymentDetailService(IGenericRepository<MonthPaymentsDetail> paymentDetailRepository)
        {
            this.paymentDetailRepository = paymentDetailRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<MonthPaymentsDetail, MonthPaymentsDetailDTO>().
                ForMember("UtilityName", opt => opt.MapFrom(d => d.Utility.UtilityName)).
                ForMember("UtilityPrice", opt => opt.MapFrom(d => d.Utility.UtilityPrice));
                cfg.CreateMap<MonthPaymentsDetailDTO, MonthPaymentsDetail>();
            }).CreateMapper();
        }

        public MonthPaymentsDetailDTO AddOrUpdate(MonthPaymentsDetailDTO obj)
        {
            try
            {
                MonthPaymentsDetail paymentDetail = _mapper.Map<MonthPaymentsDetail>(obj);
                paymentDetailRepository.AddOrUpdate(paymentDetail);
                return _mapper.Map<MonthPaymentsDetailDTO>(paymentDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MonthPaymentsDetailDTO Delete(MonthPaymentsDetailDTO obj)
        {
            try
            {
                MonthPaymentsDetail paymentDetail = _mapper.Map<MonthPaymentsDetail>(obj);
                paymentDetailRepository.Delete(paymentDetail);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MonthPaymentsDetailDTO> FindBy(Expression<Func<MonthPaymentsDetailDTO, bool>> predicate)
        {
            try
            {
                var detailPredicate = _mapper.Map<Expression<Func<MonthPaymentsDetail, bool>>>(predicate);
                return paymentDetailRepository.FindBy(detailPredicate).Select(d => _mapper.Map<MonthPaymentsDetailDTO>(d));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MonthPaymentsDetailDTO Get(int id)
        {
            try
            {
                return _mapper.Map<MonthPaymentsDetailDTO>(paymentDetailRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MonthPaymentsDetailDTO> GetAll()
        {
            try
            {
                return paymentDetailRepository.GetAll().Select(d => _mapper.Map<MonthPaymentsDetailDTO>(d));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
