﻿using Autofac;
//using HibernatingRhinos.Profiler.Appender.NHibernate;
using NUnit.Framework;

namespace ApolloDb.Tests
{
    [TestFixture]
    public class BaseTest
    {
        private static IContainer _container;

        static BaseTest()
        {
#if DEBUG
            //NHibernateProfiler.Initialize();
#endif
        }

        [SetUp]
        public void SetUp()
        {
            InitializeContainer();
        }

        private static void InitializeContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacCoreModule>();
            _container = builder.Build();
            ServiceLocator.Init(_container);
            SessionFactory.BuildSchema();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
