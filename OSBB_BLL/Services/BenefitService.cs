using OSBB_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using OSBB_DAL.Repositories;
using OSBB_DAL.Models;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

namespace OSBB_BLL.Services
{
    public class BenefitService : IGenericService<BenefitDTO>
    {
        IGenericRepository<Benefit> benefitRepository;
        readonly IMapper _mapper;
        public BenefitService(IGenericRepository<Benefit> benefitRepository)
        {
            this.benefitRepository = benefitRepository;
            _mapper = new MapperConfiguration(config =>
            {
                config.AddExpressionMapping();
                config.CreateMap<Benefit, BenefitDTO>();
                config.CreateMap<BenefitDTO, Benefit>();
            }).CreateMapper();
        }
        public BenefitDTO AddOrUpdate(BenefitDTO obj)
        {
            try
            {
                Benefit benefit = _mapper.Map<Benefit>(obj);
                benefitRepository.AddOrUpdate(benefit);
                return _mapper.Map<BenefitDTO>(benefit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BenefitDTO Delete(BenefitDTO obj)
        {
            try
            {
                Benefit benefit = _mapper.Map<Benefit>(obj);
                benefitRepository.Delete(benefit);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BenefitDTO> FindBy(Expression<Func<BenefitDTO, bool>> predicate)
        {
            try
            {
                var benefitPredicate = _mapper.Map<Expression<Func<Benefit, bool>>>(predicate);
                return benefitRepository.FindBy(benefitPredicate).Select(b => _mapper.Map<BenefitDTO>(b));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BenefitDTO Get(int id)
        {
            try
            {
                return _mapper.Map<BenefitDTO>(benefitRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BenefitDTO> GetAll()
        {
            try
            {
                return benefitRepository.GetAll().Select(b => _mapper.Map<BenefitDTO>(b));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
