using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderNumberSerieBuilder : Builder<OrderNumberSerie>
    {
        private readonly OrderNumberSerie _instance;

        public OrderNumberSerieBuilder(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException(@"Value cannot be null or empty.", "name");

            _instance = new OrderNumberSerie
            {
                Name = name
            };
        }

        public OrderNumberSerieBuilder Change(Action<OrderNumberSerie> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_instance);

            return this;
        }

        public override OrderNumberSerie Build()
        {
            return _instance;
        }
    }
}