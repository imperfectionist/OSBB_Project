﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_DAL.Repositories
{
    public class Entity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
