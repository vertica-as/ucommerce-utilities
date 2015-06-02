using System;
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
        public void Build_Complex_PurchaseOrder()
        {
            PurchaseOrder order = new PurchaseOrderBuilder()
                .OrderStatus(x => x.Name("New Order"))
                .BillingAddress(x => x
                    .FirstName("Brian").CompanyName("Vertica A/S")
                    .Line1("Studsgade 29")
                    .PostalCode("8000").City("Aarhus C")
                    .Country(c => c.Culture("da-DK")))
                .AddPayment(x => x.TransactionId("1034967282"));

            Assert.That(order.BillingAddress, Is.Not.Null);
            Assert.That(order.BillingAddress.FirstName, Is.EqualTo("Brian"));
            Assert.That(order.BillingAddress.CompanyName, Is.EqualTo("Vertica A/S"));
            Assert.That(order.BillingAddress.Line1, Is.EqualTo("Studsgade 29"));
            Assert.That(order.BillingAddress.PostalCode, Is.EqualTo("8000"));
            Assert.That(order.BillingAddress.City, Is.EqualTo("Aarhus C"));
            Assert.That(order.BillingAddress.Country, Is.Not.Null);
            Assert.That(order.BillingAddress.Country.TwoLetterISORegionName, Is.EqualTo("DK"));

            Assert.That(order.Payments.Count, Is.EqualTo(1));
            Assert.That(order.Payments.Single().TransactionId, Is.EqualTo("1034967282"));
        }

        [Test]
        public void Build_Repeat_With_Iteration_AddOrderLine()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrderBuilder()
                .Repeat(5, i => i.Context.AddOrderLine(String.Format("SKU_{0}", i.Number)));

            OrderLine[] lines = purchaseOrder.OrderLines.ToArray();

            Assert.That(lines.Length, Is.EqualTo(5));

            for (int i = 0; i < lines.Length; i++)
                Assert.That(lines[i].Sku, Is.EqualTo(String.Format("SKU_{0}", i + 1)));
        }


        [Test]
        public void Build_Repeat_Without_Iteration_AddOrderLine()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrderBuilder()
                .Repeat(5, x => x.AddOrderLine());

            OrderLine[] lines = purchaseOrder.OrderLines.ToArray();

            Assert.That(lines.Length, Is.EqualTo(5));
        }

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