using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class ShipmentBuilder : Builder<Shipment>
    {
        private decimal? _fixedShipmentTotal;

        public ShipmentBuilder(OrderAddressBuilder shipmentAddress = null)
            : base(new Shipment())
        {
            ShipmentAddress(shipmentAddress);
        }

        public ShipmentBuilder ShipmentAddress(Action<OrderAddressBuilder> shipmentAddress = null)
        {
            var builder = new OrderAddressBuilder();

            if (shipmentAddress != null)
                shipmentAddress(builder);

            return ShipmentAddress(builder);
        }

        public ShipmentBuilder ShipmentAddress(OrderAddressBuilder shipmentAddress)
        {
            return Change(x => x.ShipmentAddress = shipmentAddress);
        }

        public ShipmentBuilder Change(Action<Shipment> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(Instance);

            return this;
        }

        public ShipmentBuilder FixedShipmentTotal(decimal shipmentTotal)
        {
            _fixedShipmentTotal = shipmentTotal;
            return this;
        }

        public override Shipment Build()
        {
            if (!_fixedShipmentTotal.HasValue)
                _fixedShipmentTotal = Instance.ShipmentPrice;

            Instance.ShipmentTotal = _fixedShipmentTotal.Value;

            return base.Build();
        }
    }
}