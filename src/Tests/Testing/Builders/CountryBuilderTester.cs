using NUnit.Framework;
using UCommerce.EntitiesV2;
using Vertica.UCommerce.Utilities.Testing.Builders;

namespace Vertica.UCommerce.Utilities.Tests.Testing.Builders
{
    [TestFixture]
    public class CountryBuilderTester
    {
        [Test]
        public void Build_No_Culture()
        {
            Country country = new CountryBuilder();

            Assert.That(country.Culture, Is.Null);
        }

        [Test]
        public void Build_Chain()
        {
            Country country = new CountryBuilder("da-DK")
                .Name("Denmark");

            Assert.That(country.Culture, Is.EqualTo("da-DK"));
            Assert.That(country.Name, Is.EqualTo("Denmark"));
            Assert.That(country.TwoLetterISORegionName, Is.EqualTo("DK"));
        }
    }
}