﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Data.Entity;
using log4net;
using Xy.Pis.Contract.Message.Logistics;
using Xy.Pis.Contract.Service.Logistics;
using Xy.Pis.Domain;

namespace Xy.Pis.Service.Logistics
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WeeklyMenuService : UoWService<LmWeekFood, WeeklyMenuDTO>, IWeeklyMenuService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);       

        public DateTime GetLastSunday()
        {
            using (var command = CommandWrapper)
            {
                return command.Execute(uow => 
                {
                    var query = uow.Get<LmWeekFood>();
                    bool any = query.Any();
                    if (any)
                    {
                        return query.Max(x => x.EndDate);
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }
                });
            }
        }

        public void InsertOrUpdate(WeeklyMenuDTO weeklyMenuDto) 
        {
            using (var command = CommandWrapper)
            {
                command.Execute(uow => 
                {
                    var query = uow.Get<LmWeekFood>();
                    var weeklyMenu = query.Where(x => DbFunctions.DiffDays(x.StartDate, weeklyMenuDto.StartDate) == 0
                        && DbFunctions.DiffDays(x.EndDate, weeklyMenuDto.EndDate) == 0)
                        .AsNoTracking()
                        .FirstOrDefault();

                    if (weeklyMenu != null)
                    {

                        uow.Update<LmWeekFood>(weeklyMenu);
                    }
                    else
                    {
                        uow.Insert<LmWeekFood>(weeklyMenu);
                    }
                });
            }        
        }

        public IList<WeeklyMenuDTO> GetWeeklyMenu() 
        {
            using (var command = CommandWrapper)
            {
                return command.Execute(uow => 
                {
                    return uow.Get<LmWeekFood>();
                }).MapTo<WeeklyMenuDTO>()
                .ToList();
            }            
        }
    }
}
