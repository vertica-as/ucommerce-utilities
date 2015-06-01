using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class OrderStatusAuditBuilder : Builder<OrderStatusAudit>
    {
        private readonly OrderStatusAudit _instance;

        public OrderStatusAuditBuilder()
        {
            _instance = new OrderStatusAudit();
        }

        public OrderStatusAuditBuilder Change(Action<OrderStatusAudit> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_instance);

            return this;
        }

        public override OrderStatusAudit Build()
        {
            return _instance;
        }
    }
}