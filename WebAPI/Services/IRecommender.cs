﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IRecommender
    {
        Model.Recomender Get(int tjelesniDetaljiId);
    }
}