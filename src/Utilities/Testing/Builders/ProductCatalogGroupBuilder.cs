using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class ProductCatalogGroupBuilder : Builder<ProductCatalogGroup>
    {
        public ProductCatalogGroupBuilder()
            : base(new ProductCatalogGroup())
        {
        }

        public ProductCatalogGroupBuilder Change(Action<ProductCatalogGroup> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }

        public ProductCatalogGroupBuilder OrderNumberSerie(OrderNumberSerie orderNumberSerie)
        {
            return Change(x => x.OrderNumberSerie = orderNumberSerie);
        }

        public ProductCatalogGroupBuilder OrderNumberSerie(string name, Action<OrderNumberSerieBuilder> orderNumberSerie = null)
        {
            var builder = new OrderNumberSerieBuilder(name);

            if (orderNumberSerie != null)
                orderNumberSerie(builder);

            return OrderNumberSerie(builder);
        }
    }
}