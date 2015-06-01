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

        public OrderAddressBuilder FirstName(string firstName)
        {
            return Change(x => x.FirstName = firstName);
        }

        public OrderAddressBuilder LastName(string lastName)
        {
            return Change(x => x.LastName = lastName);
        }

        public OrderAddressBuilder CompanyName(string companyName)
        {
            return Change(x => x.CompanyName = companyName);
        }

        public OrderAddressBuilder Line1(string line1)
        {
            return Change(x => x.Line1 = line1);
        }

        public OrderAddressBuilder Line2(string line2)
        {
            return Change(x => x.Line2 = line2);
        }

        public OrderAddressBuilder PostalCode(string postalCode)
        {
            return Change(x => x.PostalCode = postalCode);
        }

        public OrderAddressBuilder City(string city)
        {
            return Change(x => x.City = city);
        }
    }
}