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
    public class ApartmentService : IGenericService<ApartmentDTO>
    {
        IGenericRepository<Apartment> apartmentRepository;
        readonly IMapper _mapper;

        public ApartmentService(IGenericRepository<Apartment> apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
            _mapper = new MapperConfiguration(config =>
            {
                config.AddExpressionMapping();
                config.CreateMap<Apartment, ApartmentDTO>()
                .ForMember("BenefitName", opt => opt.MapFrom(b => b.Benefit.BenefitName));
                config.CreateMap<ApartmentDTO, Apartment>();
            }).CreateMapper();
        }

        public ApartmentDTO AddOrUpdate(ApartmentDTO obj)
        {
            try
            {
                Apartment apartment = _mapper.Map<Apartment>(obj);
                apartmentRepository.AddOrUpdate(apartment);
                return _mapper.Map<ApartmentDTO>(apartment);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ApartmentDTO Delete(ApartmentDTO obj)
        {
            try
            {
                Apartment apartment = _mapper.Map<Apartment>(obj);
                apartmentRepository.Delete(apartment);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ApartmentDTO> FindBy(Expression<Func<ApartmentDTO, bool>> predicate)
        {
            try
            {
                var apartmentPredicate = _mapper.Map<Expression<Func<Apartment, bool>>>(predicate);
                return apartmentRepository.FindBy(apartmentPredicate).Select(ap => _mapper.Map<ApartmentDTO>(ap));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApartmentDTO Get(int id)
        {
            try
            {
                return _mapper.Map<ApartmentDTO>(apartmentRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ApartmentDTO> GetAll()
        {
            try
            {
                return apartmentRepository.GetAll().Select(ap => _mapper.Map<ApartmentDTO>(ap));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
