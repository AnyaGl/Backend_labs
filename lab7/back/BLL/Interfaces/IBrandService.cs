﻿using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBrandService
    {
        List<BrandDTO> GetBrands();
    }
}
