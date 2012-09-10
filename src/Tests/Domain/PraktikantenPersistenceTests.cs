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
            var kandidat = new Kandidat();
            kandidat.Familienname = "Familienname";
            kandidat.FamiliennameKY = "Кирилица";
            kandidat.Deutschkentnisse = false;
            kandidat.EmailAdresse = "test@test.de";
            kandidat.VornameKY = "VornameKY";
            kandidat.VatersnameKY = "VatersnameKY";
            kandidat.Status = KandidatStatus.Registriert;

            Resolve<KandidatRepository>().Create(kandidat);

            var fromDb = Resolve<KandidatRepository>().GetById(kandidat.Id);
            Assert.That(fromDb.Familienname, Is.EqualTo("Familienname"));
            Assert.That(fromDb.FamiliennameKY, Is.EqualTo("Кирилица"));
            Assert.That(fromDb.Deutschkentnisse, Is.EqualTo(false));
        }
    }
}
