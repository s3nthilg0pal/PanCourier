namespace PanCourier.Shipping.Contracts;

public record Consignment(ICollection<Parcel> Parcels, bool OptForSpeedyShipping = false);