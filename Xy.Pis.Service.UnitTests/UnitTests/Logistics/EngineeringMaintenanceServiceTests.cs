﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using log4net;
using Microsoft.Practices.Unity;
using Xunit;
using Xy.Pis.Contract.Message.Logistics;
using Xy.Pis.Contract.Service.Logistics;
using Xy.Pis.Proxy;

namespace Xy.Pis.Service.UnitTests.Logistics
{    
    public partial class EngineeringMaintenanceServiceTests : TestBase
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);        

        [Fact]
        public void Test_EngineeringMaintenanceService_Add()
        {
            int id = this.Add();

            Assert.NotEqual(0, id);
        }

        [Fact]
        public void Test_EngineeringMaintenanceService_GetAll()
        {
            int id = this.Add();
            var response = ServiceWrapper.Invoke<IEngineeringMaintenanceService, IEnumerable<EngineeringMaintenanceDTO>>(x => x.GetAll());
            Assert.True(response.Status == ResponseStatus.OK);
            Assert.True(response.Result.Where(x => x.ID == id).Any());
        }

        [Fact]
        public void Test_EngineeringMaintenanceService_GetById()
        {
            int id = this.Add();
            var getResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService, EngineeringMaintenanceDTO>(x => x.GetById(id));
            Assert.True(getResponse.Status == ResponseStatus.OK);
            Assert.NotNull(getResponse.Result);
        }

        [Fact]
        public void Test_EngineeringMaintenanceService_Update()
        {
            int id = this.Add();
            var getResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService, EngineeringMaintenanceDTO>(x => x.GetById(id));
            Assert.True(getResponse.Status == ResponseStatus.OK);
            Assert.NotNull(getResponse.Result);

            var dto = getResponse.Result;
            dto.Memo = "数据更新测试...";
            dto.OperId = 6768;

            var updateResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService>(x => x.Update(dto));
            Assert.True(updateResponse.Status == ResponseStatus.OK);            
        }

        [Fact]
        public void Test_EngineeringMaintenanceService_Delete()
        {
            int id = this.Add();
            var getResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService, EngineeringMaintenanceDTO>(x => x.GetById(id));
            Assert.True(getResponse.Status == ResponseStatus.OK);

            EngineeringMaintenanceDTO dto = getResponse.Result;
            Assert.NotNull(dto);

            var deleteResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService>(x => x.Delete(dto));
            Assert.True(deleteResponse.Status == ResponseStatus.OK);            
        }

        [Fact]
        public void Test_EngineeringMaintenanceService_AddOrUpdate()
        {
            var getResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService, IEnumerable<EngineeringMaintenanceDTO>>(x => x.GetAll().Where(y => y.OperId != 6768));

            List<EngineeringMaintenanceDTO> addDTOs = new List<EngineeringMaintenanceDTO>();
            addDTOs.Add(new EngineeringMaintenanceDTO()
            {
                Name = "空调",
                Position = "松鹤北",
                LocationId = 1517,
                RepairLocationId = 1559,
                CompletionBeginTime = DateTime.Now.AddDays(-5),
                CompletionEndTime = null,
                LsStatus = 1,
                Memo = string.Empty,
                OperId = 9,
                OperTime = DateTime.Now
            });

            addDTOs.Add(new EngineeringMaintenanceDTO()
            {
                Name = "电风扇",
                Position = "松鹤南",
                LocationId = 1517,
                RepairLocationId = 1559,
                CompletionBeginTime = DateTime.Now.AddDays(-5),
                CompletionEndTime = null,
                LsStatus = 1,
                Memo = string.Empty,
                OperId = 9,
                OperTime = DateTime.Now
            });

            List<EngineeringMaintenanceDTO> addOrUpdateDTOs = new List<EngineeringMaintenanceDTO>();
            var updateDTOs = getResponse.Result.Where(x => x.OperId == 9).ToList();
            updateDTOs.ForEach(x =>
            {
                x.Memo = "AddOrUpdate 测试 ....";
            });

            addOrUpdateDTOs.AddRange(addDTOs);
            addOrUpdateDTOs.AddRange(updateDTOs);

            var updateResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService, Tuple<int, int>>(x => x.AddOrUpdate(addOrUpdateDTOs));
            Assert.True(updateResponse.Status == ResponseStatus.OK);
            Assert.Equal(addDTOs.Count, updateResponse.Result.Item1);
            Assert.Equal(updateDTOs.Count, updateResponse.Result.Item2);
        }        

         [Fact]
        public void Test_EngineeringMaintenanceService_GetByLambdaExpression()
        {
            var getResponse = ServiceWrapper.Invoke<IEngineeringMaintenanceService, IEnumerable<EngineeringMaintenanceDTO>>(x => x.Get(y => y.Name.Contains("柜子") || y.Memo.Contains("柜子") || y.Position.Contains("万寿楼")));
            Assert.True(getResponse.Status == ResponseStatus.OK);
            Assert.True(getResponse.Result.Count() > 0);
        }

         private int Add()
         {
             var expectedDto = new EngineeringMaintenanceDTO()
             {
                 Name = "柜子",
                 Position = "万寿楼",
                 LocationId = 1517,
                 RepairLocationId = 1559,
                 CompletionBeginTime = DateTime.Now.AddDays(-5),
                 CompletionEndTime = DateTime.Now.AddDays(-4),
                 LsStatus = 2,
                 Memo = string.Empty,
                 OperId = 9,
                 OperTime = DateTime.Now
             };

             var response = ServiceWrapper.Invoke<IEngineeringMaintenanceService, EngineeringMaintenanceDTO>(x => x.Add(expectedDto));

             Assert.True(response.Status == ResponseStatus.OK);
             Assert.NotNull(response.Result);
             Assert.NotEqual(0, response.Result.ID);

             return response.Result.ID;
         }
    }
}