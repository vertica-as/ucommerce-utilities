using NUnit.Framework;
using UCommerce.EntitiesV2;
using Vertica.UCommerce.Utilities.Testing.Builders;

namespace Vertica.UCommerce.Utilities.Tests.Testing.Builders
{
    [TestFixture]
    public class OrderLineBuilderTester
    {
        [Test]
        public void Build_No_Sku()
        {
            OrderLine orderLine = new OrderLineBuilder();

            Assert.That(orderLine.Sku, Is.Null);
            Assert.That(orderLine.VariantSku, Is.Null);
        }

        [Test]
        public void Build_Specify_Sku()
        {
            OrderLine orderLine = new OrderLineBuilder("SKU");

            Assert.That(orderLine.Sku, Is.EqualTo("SKU"));
            Assert.That(orderLine.VariantSku, Is.Null);
        }

        [Test]
        public void Build_Specify_Sku_And_VariantSku()
        {
            OrderLine orderLine = new OrderLineBuilder("SKU", "VARIANTSKU");

            Assert.That(orderLine.Sku, Is.EqualTo("SKU"));
            Assert.That(orderLine.VariantSku, Is.EqualTo("VARIANTSKU"));
        }

        [Test]
        public void Build_Specify_Quantity()
        {
            OrderLine orderLine = new OrderLineBuilder("SKU")
                .Quantity(10);

            Assert.That(orderLine.Quantity, Is.EqualTo(10));            
        }


        [Test]
        public void Build_Specify_Price()
        {
            OrderLine orderLine = new OrderLineBuilder("SKU")
                .Price(100m);

            Assert.That(orderLine.Price, Is.EqualTo(100m));
        }
    }
}