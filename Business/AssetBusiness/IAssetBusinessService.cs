﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.AssetBusiness
{
    public interface IAssetBusinessService
    {
        bool UpSertAsset();
        List<Asset> GetAllAssets();
    }
}
