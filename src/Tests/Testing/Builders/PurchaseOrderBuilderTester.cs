using System.Linq;
using NUnit.Framework;
using UCommerce.EntitiesV2;
using Vertica.UCommerce.Utilities.Testing.Builders;

namespace Vertica.UCommerce.Utilities.Tests.Testing.Builders
{
    [TestFixture]
    public class PurchaseOrderBuilderTester
    {
        [Test]
        public void Build_AddOrderLine_Different_Strategies()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrderBuilder()
                .AddOrderLine("ProductA")
                .AddOrderLine("ProductB", l => l.Price(100m))
                .AddOrderLine("ProductC", "Variant1")
                .AddOrderLine("ProductD", "Variant2", l => l.Price(150m))
                .AddOrderLine(l => l.Price(200m));

            OrderLine[] lines = purchaseOrder.OrderLines.ToArray();

            Assert.That(lines.Length, Is.EqualTo(5));
        }
    }
}