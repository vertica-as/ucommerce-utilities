using System;
using UCommerce.EntitiesV2;
using Vertica.UCommerce.Utilities.Infrastructure;
using Vertica.UCommerce.Utilities.Infrastructure.Extensions;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class PurchaseOrderBuilder : Builder<PurchaseOrder>
    {
        public PurchaseOrderBuilder(OrderStatusBuilder status = null)
            : base(new PurchaseOrder())
        {
            OrderStatus(status);
        }

        public PurchaseOrderBuilder AddOrderStatusAudit(Action<OrderStatusAuditBuilder> orderStatusAudit = null)
        {
            var builder = new OrderStatusAuditBuilder();

            if (orderStatusAudit != null)
                orderStatusAudit(builder);

            return AddOrderStatusAudit(builder);
        }

        public PurchaseOrderBuilder AddOrderStatusAudit(OrderStatusAuditBuilder orderStatusAudit)
        {
            return AddOrderStatusAudit((OrderStatusAudit) orderStatusAudit);
        }

        public PurchaseOrderBuilder AddOrderStatusAudit(OrderStatusAudit orderStatusAudit)
        {
            if (orderStatusAudit == null) throw new ArgumentNullException("orderStatusAudit");

            Instance.AddOrderStatusAudit(orderStatusAudit);

            return this;
        }

        public PurchaseOrderBuilder OrderStatus(OrderStatusBuilder orderStatus)
        {
            return OrderStatus((OrderStatus)orderStatus);
        }

        public PurchaseOrderBuilder OrderStatus(Action<OrderStatusBuilder> orderStatus = null)
        {
            var builder = new OrderStatusBuilder();

            if (orderStatus != null)
                orderStatus(builder);

            return OrderStatus(builder);
        }

        public PurchaseOrderBuilder OrderStatus(OrderStatus orderStatus)
        {
            Instance.OrderStatus = orderStatus;

            return this;
        }

        public PurchaseOrderBuilder AddShipment(Action<ShipmentBuilder> shipment)
        {
            var builder = new ShipmentBuilder();

            if (shipment != null)
                shipment(builder);

            return AddShipment(builder);
        }

        public PurchaseOrderBuilder AddShipment(Shipment shipment)
        {
            if (shipment == null) throw new ArgumentNullException("shipment");

            Instance.AddShipment(shipment);

            return this;
        }

        public PurchaseOrderBuilder AddOrderLine(OrderLine orderLine)
        {
            if (orderLine == null) throw new ArgumentNullException("orderLine");

            Instance.AddOrderLine(orderLine);

            return this;
        }

        public PurchaseOrderBuilder AddOrderLine(Action<OrderLineBuilder> orderLine = null)
        {
            return AddOrderLine(null, null, orderLine);
        }

        public PurchaseOrderBuilder AddOrderLine(string sku, Action<OrderLineBuilder> orderLine = null)
        {
            return AddOrderLine(sku, null, orderLine);
        }

        public PurchaseOrderBuilder AddOrderLine(string sku, string variantSku, Action<OrderLineBuilder> orderLine = null)
        {
            var builder = new OrderLineBuilder(sku, variantSku);

            if (orderLine != null)
                orderLine(builder);

            return AddOrderLine(builder);
        }

        public PurchaseOrderBuilder AddPayment(Action<PaymentBuilder> payment = null)
        {
            var builder = new PaymentBuilder();

            if (payment != null)
                payment(builder);

            return AddPayment(builder);
        }

        public PurchaseOrderBuilder AddPayment(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException("payment");

            Instance.AddPayment(payment);

            return this;
        }

        public PurchaseOrderBuilder BillingAddress(Action<OrderAddressBuilder> billingAddress = null)
        {
            var builder = new OrderAddressBuilder();

            if (billingAddress != null)
                billingAddress(builder);

            Instance.BillingAddress = builder;

            return this;
        }

        public PurchaseOrderBuilder ProductCatalogGroup(ProductCatalogGroup productCatalogGroup)
        {
            if (productCatalogGroup == null) throw new ArgumentNullException("productCatalogGroup");

            Instance.ProductCatalogGroup = productCatalogGroup;

            return this;
        }

        public PurchaseOrderBuilder Repeat(uint times, Action<PurchaseOrderBuilder> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            // ReSharper disable once UnusedVariable
            foreach (int iteration in times.Repeat())
                action(this);

            return this;
        }

        public PurchaseOrderBuilder Repeat(uint times, Action<Iteration<PurchaseOrderBuilder>> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            foreach (Iteration<PurchaseOrderBuilder> iteration in times.Repeat(this))
                action(iteration);

            return this;
        }

        public PurchaseOrderBuilder Change(Action<PurchaseOrder> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }
    }
}