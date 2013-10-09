using System.Collections.Generic;
using NUnit.Framework;

namespace ApolloDb.Tests
{
    
    public class IsEmailAddressInUseTest 
    {
        [Test]
        public void Should_identify_that_email_address_is_in_use()
        {
            //Assert.That(Resolve<IsEmailAddressInUse>().Yes("test@test.de"), Is.False);
            //Resolve<KandidatRepository>().Create(new Kandidat{EmailAdresse = "test@test.de"});
            //Assert.That(Resolve<IsEmailAddressInUse>().Yes("test@test.de"), Is.True);

        }

        [Test]
        public void Should_sanitize_names()
        {
            Assert.That(1,Is.EqualTo(1));
            Assert.That(1, Is.EqualTo(1));

            var praktis = new List<Kandidat>();
            praktis.Add(new Kandidat() { Vorname = "robeRt" });
            praktis.Add(new Kandidat() { Vorname = "" });
            praktis.Add(new Kandidat() { Vatersname = "MISCHKE" });
            praktis.Add(new Kandidat() { Vatersname = "панасенко" });


            NamensBereiniger.Run(praktis);
                  
            Assert.That(praktis[0].Vorname, Is.EqualTo("Robert"));
            Assert.That(praktis[3].Vatersname, Is.EqualTo("Панасенко"));


        }

        public class NamensBereiniger
        {
            public static void Run(List<Kandidat> praktis)
            {
                foreach (var p in praktis)
                {
                    p.Vorname = Sanitize(p.Vorname);
                    p.VornameKY = Sanitize(p.VornameKY);
                    p.Vatersname = Sanitize(p.Vatersname);
                    p.VatersnameKY = Sanitize(p.VatersnameKY);
                    p.Familienname = Sanitize(p.Familienname);
                    p.FamiliennameKY = Sanitize(p.FamiliennameKY);

                }
            }

            private static string Sanitize(string stringSanitize)
            {
                if (stringSanitize == null)
                    return "";

                stringSanitize = stringSanitize.ToLower();
                if (stringSanitize.Length > 0)
                    stringSanitize = stringSanitize[0].ToString().ToUpper().ToCharArray()[0] + stringSanitize.Substring(1);

                return stringSanitize;
            }
        }
    }
}
