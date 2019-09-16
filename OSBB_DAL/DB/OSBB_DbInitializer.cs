using OSBB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_DAL.DB
{
    public class OSBB_DbInitializer : CreateDatabaseIfNotExists<OSBB_Context>
    {
        protected override void Seed(OSBB_Context context)
        {
            IList<Benefit> defaultBenefits = new List<Benefit>();

            defaultBenefits.Add(new Benefit { BenefitName = "Учасник бойових дій", BenefitPercent = 75 });
            defaultBenefits.Add(new Benefit { BenefitName = "Багатодітна сім’я", BenefitPercent = 50 });
            defaultBenefits.Add(new Benefit { BenefitName = "Особа ЧАЕС – 2 категорія – ліквідатор", BenefitPercent = 50 });
            defaultBenefits.Add(new Benefit { BenefitName = "Особа ЧАЕС – 2 категорія – потерпілий", BenefitPercent = 50 });

            context.Benefits.AddRange(defaultBenefits);

            base.Seed(context);
        }
    }
}
