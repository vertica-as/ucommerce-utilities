using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderAddressBuilder : Builder<OrderAddress>
    {
        private readonly OrderAddress _instance;

        public OrderAddressBuilder(CountryBuilder country = null)
        {
            _instance = new OrderAddress();

            Country(country);
        }

        public OrderAddressBuilder Country(Action<CountryBuilder> country = null)
        {
            var builder = new CountryBuilder();

            if (country != null)
                country(builder);

            return Country(builder);
        }

        public OrderAddressBuilder Country(CountryBuilder country)
        {
            _instance.Country = country;

            return this;
        }

        public OrderAddressBuilder Change(Action<OrderAddress> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_instance);

            return this;
        }

        public override OrderAddress Build()
        {
            return _instance;
        }
    }
}