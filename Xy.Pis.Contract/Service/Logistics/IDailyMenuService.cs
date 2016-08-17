﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Xy.Pis.Contract.Message.Logistics;

namespace Xy.Pis.Contract.Service.Logistics
{
    [ServiceContract]
    public interface IDailyMenuService : IService<FoodDTO>
    {
        [OperationContract]
        IEnumerable<FoodDTO> GetMenuListByType(int type);
    }
}
