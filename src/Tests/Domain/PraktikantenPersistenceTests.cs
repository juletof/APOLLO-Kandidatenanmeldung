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
            praktikant.Familienname = "Familienname";
            praktikant.FamiliennameKY = "Кирилица";
            praktikant.Deutschkentnisse = false;

            Resolve<PraktikantRepository>().Create(praktikant);

            var fromDb = Resolve<PraktikantRepository>().GetById(praktikant.Id);
            Assert.That(fromDb.Familienname, Is.EqualTo("Familienname"));
            Assert.That(fromDb.FamiliennameKY, Is.EqualTo("Кирилица"));
            Assert.That(fromDb.Deutschkentnisse, Is.EqualTo(false));
        }
    }
}
