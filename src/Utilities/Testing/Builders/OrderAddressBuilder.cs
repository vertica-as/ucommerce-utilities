using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderAddressBuilder : Builder<OrderAddress>
    {
        public OrderAddressBuilder(CountryBuilder country = null)
            : base(new OrderAddress())
        {
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
            Instance.Country = country;

            return this;
        }

        public OrderAddressBuilder Change(Action<OrderAddress> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }
    }
}