using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class PurchaseOrderBuilder : Builder<PurchaseOrder>
    {
        private readonly PurchaseOrder _purchaseOrder;

        public PurchaseOrderBuilder(OrderStatusBuilder status = null)
        {
            _purchaseOrder = new PurchaseOrder();
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

            _purchaseOrder.AddOrderStatusAudit(orderStatusAudit);

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
            _purchaseOrder.OrderStatus = orderStatus;

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

            _purchaseOrder.AddShipment(shipment);

            return this;
        }

        public PurchaseOrderBuilder AddOrderLine(OrderLine orderLine)
        {
            if (orderLine == null) throw new ArgumentNullException("orderLine");

            _purchaseOrder.AddOrderLine(orderLine);

            return this;
        }

        public PurchaseOrderBuilder AddOrderLine(Action<OrderLineBuilder> orderLine)
        {
            return AddOrderLine(null, null, orderLine);
        }

        public PurchaseOrderBuilder AddOrderLine(string sku, Action<OrderLineBuilder> orderLine)
        {
            return AddOrderLine(sku, null, orderLine);
        }

        public PurchaseOrderBuilder AddOrderLine(string sku, string variantSku, Action<OrderLineBuilder> orderLine)
        {
            if (orderLine == null) throw new ArgumentNullException("orderLine");

            var builder = new OrderLineBuilder(sku, variantSku);
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

            _purchaseOrder.AddPayment(payment);

            return this;
        }

        public PurchaseOrderBuilder BillingAddress(Action<OrderAddressBuilder> billingAddress = null)
        {
            var builder = new OrderAddressBuilder();

            if (billingAddress != null)
                billingAddress(builder);

            _purchaseOrder.BillingAddress = builder;

            return this;
        }

        public PurchaseOrderBuilder Change(Action<PurchaseOrder> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_purchaseOrder);

            return this;
        }

        public override PurchaseOrder Build()
        {
            return _purchaseOrder;
        }

        public PurchaseOrder SetProductCatalogGroup(ProductCatalogGroup productCatalogGroup)
        {
            if (productCatalogGroup == null) throw new ArgumentNullException("productCatalogGroup");

            _purchaseOrder.ProductCatalogGroup = productCatalogGroup;

            return this;
        }
    }
}