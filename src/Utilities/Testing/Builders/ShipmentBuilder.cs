using System;
using UCommerce.EntitiesV2;

namespace Vertica.UCommerce.Utilities.Testing.Builders
{
    public class ShipmentBuilder : Builder<Shipment>
    {
        private readonly Shipment _shipment;
        private decimal? _shipmentTotal;

        public ShipmentBuilder(OrderAddressBuilder shipmentAddress = null)
        {
            _shipment = new Shipment();
            Address(shipmentAddress);
        }

        public ShipmentBuilder Address(Action<OrderAddressBuilder> shipmentAddress = null)
        {
            var builder = new OrderAddressBuilder();

            if (shipmentAddress != null)
                shipmentAddress(builder);

            return Address(builder);
        }

        public ShipmentBuilder Address(OrderAddressBuilder shipmentAddress)
        {
            _shipment.ShipmentAddress = shipmentAddress;

            return this;
        }

        public ShipmentBuilder Change(Action<Shipment> change)
        {
            if (change == null) throw new ArgumentNullException("change");

            change(_shipment);

            return this;
        }

        public ShipmentBuilder SetSpecificShipmentTotal(decimal shipmentTotal)
        {
            _shipmentTotal = shipmentTotal;
            return this;
        }

        public override Shipment Build()
        {
            if (!_shipmentTotal.HasValue)
                _shipmentTotal = _shipment.ShipmentPrice;

            _shipment.ShipmentTotal = _shipmentTotal.Value;

            return _shipment;
        }
    }
}