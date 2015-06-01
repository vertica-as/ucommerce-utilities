using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderNumberSerieBuilder : Builder<OrderNumberSerie>
    {
        public OrderNumberSerieBuilder(string name)
            : base(new OrderNumberSerie { Name = name })
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException(@"Value cannot be null or empty.", "name");
        }

        public OrderNumberSerieBuilder Change(Action<OrderNumberSerie> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }
    }
}