using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderStatusBuilder : Builder<OrderStatus>
    {
        public OrderStatusBuilder()
            : base(new OrderStatus())
        {
        }

        public OrderStatusBuilder Name(string name)
        {
            return Change(x => x.Name = name);
        }

        public OrderStatusBuilder Change(Action<OrderStatus> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }
    }
}