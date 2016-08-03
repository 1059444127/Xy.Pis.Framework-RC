﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Xy.Pis.Contract.Message.Logistics;
using Xy.Pis.Contract.Service.Logistics;
using Xy.Pis.Domain;

namespace Xy.Pis.Service.Logistics
{
    public class EngineeringMaintenanceService : UoWService<LmWorkRepair, EngineeringMaintenanceDTO>, IEngineeringMaintenanceService
    {
    }
}