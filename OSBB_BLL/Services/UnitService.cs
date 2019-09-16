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
    public class UnitService : IGenericService<UnitDTO>
    {
        IGenericRepository<Unit> unitRepository;
        readonly IMapper _mapper;

        public UnitService(IGenericRepository<Unit> unitRepository)
        {
            this.unitRepository = unitRepository;
            _mapper = new MapperConfiguration(config =>
            {
                config.AddExpressionMapping();
                config.CreateMap<Unit, UnitDTO>();
                config.CreateMap<UnitDTO, Unit>();
            }).CreateMapper();
        }
        public UnitDTO AddOrUpdate(UnitDTO obj)
        {
            try
            {
                Unit unit = _mapper.Map<Unit>(obj);
                unitRepository.AddOrUpdate(unit);
                return _mapper.Map<UnitDTO>(unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UnitDTO Delete(UnitDTO obj)
        {
            try
            {
                Unit unit = _mapper.Map<Unit>(obj);
                unitRepository.Delete(unit);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UnitDTO> FindBy(Expression<Func<UnitDTO, bool>> predicate)
        {
            try
            {
                var unitPredicate = _mapper.Map<Expression<Func<Unit, bool>>>(predicate);
                return unitRepository.FindBy(unitPredicate).Select(u => _mapper.Map<UnitDTO>(u));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UnitDTO Get(int id)
        {
            try
            {
                return _mapper.Map<UnitDTO>(unitRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UnitDTO> GetAll()
        {
            try
            {
                return unitRepository.GetAll().Select(u => _mapper.Map<UnitDTO>(u));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
