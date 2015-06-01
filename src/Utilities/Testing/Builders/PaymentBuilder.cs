using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class PaymentBuilder : Builder<Payment>
    {
        public PaymentBuilder()
            : base(new Payment())
        {
        }

        public PaymentBuilder TransactionId(string transactionId)
        {
            return Change(x => x.TransactionId = transactionId);
        }

        public PaymentBuilder Change(Action<Payment> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }
    }
}