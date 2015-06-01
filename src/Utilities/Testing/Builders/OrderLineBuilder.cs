using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderLineBuilder : Builder<OrderLine>
    {
        private decimal? _total;

        public OrderLineBuilder()
            : base(new OrderLine { PurchaseOrder = new PurchaseOrder() })
        {
        }

        public OrderLineBuilder(string sku, string variantSku = null)
            : this()
        {
            Instance.Sku = sku;
            Instance.VariantSku = variantSku;
        }

        public OrderLineBuilder Total(decimal total)
        {
            _total = total;
            return this;
        }

        public override OrderLine Build()
        {
            if (!_total.HasValue)
                _total = (Instance.Price*Instance.Quantity);

            Instance.Total = _total.Value;

            return base.Build();
        }

        public OrderLineBuilder Change(Action<OrderLine> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }

        public OrderLineBuilder Quantity(int quantity)
        {
            return Change(x => x.Quantity = quantity);
        }

        public OrderLineBuilder Price(decimal price)
        {
            return Change(x => x.Price = price);
        }
    }
}