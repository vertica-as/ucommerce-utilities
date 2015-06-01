using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderStatusAuditBuilder : Builder<OrderStatusAudit>
    {
        public OrderStatusAuditBuilder()
            : base(new OrderStatusAudit())
        {
        }

        public OrderStatusAuditBuilder Change(Action<OrderStatusAudit> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }
    }
}