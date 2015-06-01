using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class CountryBuilder : Builder<Country>
    {
        public CountryBuilder(string culture = null)
            : base(new Country())
        {
            Change(x => x.Culture = culture);
        }

        public CountryBuilder Culture(string culture)
        {
            return Change(x => x.Culture = culture);
        }

        public CountryBuilder Change(Action<Country> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }

        public CountryBuilder Name(string name)
        {
            return Change(x => x.Name = name);
        }
    }
}