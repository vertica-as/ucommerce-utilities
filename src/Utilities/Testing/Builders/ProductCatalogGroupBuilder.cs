using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class ProductCatalogGroupBuilder : Builder<ProductCatalogGroup>
    {
        private readonly ProductCatalogGroup _instance;

        public ProductCatalogGroupBuilder()
        {
            _instance = new ProductCatalogGroup();
        }

        public ProductCatalogGroupBuilder Change(Action<ProductCatalogGroup> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_instance);

            return this;
        }

        public ProductCatalogGroupBuilder SetOrderNumberSerie(OrderNumberSerie orderNumberSerie)
        {
            if (orderNumberSerie == null) throw new ArgumentNullException("orderNumberSerie");

            _instance.OrderNumberSerie = orderNumberSerie;

            return this;
        }

        public override ProductCatalogGroup Build()
        {
            return _instance;
        }
    }
}