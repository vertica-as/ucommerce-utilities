using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class CountryBuilder : Builder<Country>
    {
        private readonly Country _instance;

        public CountryBuilder(string culture = null)
        {
            _instance = new Country();

            Change(x => x.Culture = culture);
        }

        public CountryBuilder Culture(string culture)
        {
            return Change(x => x.Culture = culture);
        }

        public CountryBuilder Change(Action<Country> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_instance);

            return this;
        }

        public override Country Build()
        {
            return _instance;
        }
    }
}