using Autofac;
using OSBB_BLL.Models;
using OSBB_BLL.Services;
using OSBB_DAL.Models;
using OSBB_DAL.Repositories;
using OSBB_DAL.Repositories.CustomRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(OSBB_Context)).As(typeof(DbContext)).InstancePerLifetimeScope();
            // Apartment
            builder.RegisterType(typeof(ApartmentRepository)).As(typeof(IGenericRepository<Apartment>));
            builder.RegisterType(typeof(ApartmentService)).As(typeof(IGenericService<ApartmentDTO>));
            // Benefit
            builder.RegisterType(typeof(BenefitRepository)).As(typeof(IGenericRepository<Benefit>));
            builder.RegisterType(typeof(BenefitService)).As(typeof(IGenericService<BenefitDTO>));
            // Unit
            builder.RegisterType(typeof(UnitRepository)).As(typeof(IGenericRepository<Unit>));
            builder.RegisterType(typeof(UnitService)).As(typeof(IGenericService<UnitDTO>));
            // Utility
            builder.RegisterType(typeof(UtilityRepository)).As(typeof(IGenericRepository<Utility>));
            builder.RegisterType(typeof(UtilityService)).As(typeof(IGenericService<UtilityDTO>));
            // MonthPayment
            builder.RegisterType(typeof(MonthPaymentRepository)).As(typeof(IGenericRepository<MonthPayment>));
            builder.RegisterType(typeof(MonthPaymentService)).As(typeof(IGenericService<MonthPaymentDTO>));
            // MonthPaymentsDetail
            builder.RegisterType(typeof(MonthPaymentsDetailRepository)).As(typeof(IGenericRepository<MonthPaymentsDetail>));
            builder.RegisterType(typeof(MonthPaymentDetailService)).As(typeof(IGenericService<MonthPaymentsDetailDTO>));
        }
    }
}
