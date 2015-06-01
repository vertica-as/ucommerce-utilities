using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderLineBuilder : Builder<OrderLine>
    {
        private readonly OrderLine _orderLine;
        private decimal? _total;

        public OrderLineBuilder()
        {
            _orderLine = new OrderLine
            {
                Quantity = 1,
                PurchaseOrder = new PurchaseOrder()
            };            
        }

        public OrderLineBuilder(string sku, string variantSku = null)
            : this()
        {
            _orderLine.Sku = sku;
            _orderLine.VariantSku = variantSku;
        }

        public OrderLineBuilder SetSpecificTotal(decimal total)
        {
            _total = total;
            return this;
        }

        public OrderLineBuilder Change(Action<OrderLine> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_orderLine);

            return this;
        }

        public override OrderLine Build()
        {
            if (!_total.HasValue)
                _total = (_orderLine.Price*_orderLine.Quantity);

            _orderLine.Total = _total.Value;

            return _orderLine;
        }
    }
}