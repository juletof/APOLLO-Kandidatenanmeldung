using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ApolloDb.Tests
{
    public class NamensbereinigerTests
    {

        [Test]
        public void Should_sanitize_names()
        {
            var praktis = new List<Kandidat>{
                new Kandidat {Vorname = "robeRt"},
                new Kandidat {Vorname = ""},
                new Kandidat {Vorname = null},
                new Kandidat {Vatersname = "MISCHKE"},
                new Kandidat {Vatersname = "панасенко"}
            };

            NamensBereiniger.Run(praktis);

            Assert.That(praktis[0].Vorname, Is.EqualTo("Robert"));
            Assert.That(praktis[3].Vorname, Is.EqualTo(""));
            Assert.That(praktis[4].Vatersname, Is.EqualTo("Панасенко"));
        }
    }
}
