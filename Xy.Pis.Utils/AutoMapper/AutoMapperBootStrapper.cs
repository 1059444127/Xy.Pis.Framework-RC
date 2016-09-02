﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Xy.Pis.Utils.AutoMapper
{
    public sealed class AutoMapperBootStrapper
    {
        public static void Initialize(Assembly[] assemblies)
        {
            Mapper.Initialize(cfg =>
            {
                foreach (var assembly in assemblies) 
                {
                    AddProfile(cfg, assembly); 
                }
            });             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="assembly"></param>
        private static void AddProfile(IConfiguration config, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface) 
                {
                    continue;
                }

                if (typeof(Profile).IsAssignableFrom(type))
                {
                    config.AddProfile(Activator.CreateInstance(type) as Profile);
                }
            }            
        }
    }
}
