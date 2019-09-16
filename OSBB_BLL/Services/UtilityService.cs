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
    public class UtilityService : IGenericService<UtilityDTO>
    {
        IGenericRepository<Utility> utilityRepository;
        readonly IMapper _mapper;

        public UtilityService(IGenericRepository<Utility> utilityRepository)
        {
            this.utilityRepository = utilityRepository;
            _mapper = new MapperConfiguration(config =>
            {
                config.AddExpressionMapping();
                config.CreateMap<Utility, UtilityDTO>()
                .ForMember("UnitName", opt => opt.MapFrom(u => u.Unit.UnitName));
                config.CreateMap<UtilityDTO, Utility>();
            }).CreateMapper();
        }
        public UtilityDTO AddOrUpdate(UtilityDTO obj)
        {
            try
            {
                Utility utility = _mapper.Map<Utility>(obj);
                utilityRepository.AddOrUpdate(utility);
                return _mapper.Map<UtilityDTO>(utility);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UtilityDTO Delete(UtilityDTO obj)
        {
            try
            {
                Utility utility = _mapper.Map<Utility>(obj);
                utilityRepository.Delete(utility);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UtilityDTO> FindBy(Expression<Func<UtilityDTO, bool>> predicate)
        {
            try
            {
                var utilityPredicate = _mapper.Map<Expression<Func<Utility, bool>>>(predicate);
                return utilityRepository.FindBy(utilityPredicate).Select(util => _mapper.Map<UtilityDTO>(util));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UtilityDTO Get(int id)
        {
            try
            {
                return _mapper.Map<UtilityDTO>(utilityRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UtilityDTO> GetAll()
        {
            try
            {
                return utilityRepository.GetAll().Select(util => _mapper.Map<UtilityDTO>(util));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
