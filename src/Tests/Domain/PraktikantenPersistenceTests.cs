using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ApolloDb.Tests
{
    public class PraktikantenPersistenceTests : BaseTest
    {
        [Test]
        public void Should_CRUD_Praktikant()
        {
            var praktikant = new Praktikant();
            praktikant.Name = "Some name";

            Resolve<PraktikantRepository>().Create(praktikant);
        }
    }
}
