﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;

namespace BLL.Interfaces
{
    public interface IRubroService
    {
        Task<List<Rubro>> Lista();

    }
}
