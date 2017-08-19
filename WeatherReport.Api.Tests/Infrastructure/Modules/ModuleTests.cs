using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NUnit.Framework;
using WeatherReport.Api.Controllers;
using FluentAssertions;

namespace WeatherReport.Api.Tests.Infrastructure.Modules
{
    public class ModuleTests
    {
        [TestCaseSource(nameof(TestCaseSource))]
        public void Can_resolve_components(Type type)
        {
            Given.AnInitializedContainer
                .IsRegistered(type)
                .Should()
                .BeTrue();
        }

        public static List<TestCaseData> TestCaseSource()
        {
            var typesToResolve = new List<Type>
            {
                typeof(WeatherController),
                typeof(CitiesController),
            };

            return typesToResolve
                .Select(x => new TestCaseData(x)
                {
                    //TestName = $"Can_resolve_{x.Name}"
                })
                .ToList();
        }

        public static class Given
        {
            public static IContainer AnInitializedContainer
            {
                get
                {
                    var builder = new ContainerBuilder();
                    //builder.RegisterAssemblyModules(WeatherApiModule.Assembly);

                    return builder.Build();
                }
            }
        }
    }
}