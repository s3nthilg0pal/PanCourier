using PanCourier.Shipping.Contracts;

namespace PanCourier.Shipping.Interfaces;

public interface IParcelShippingCostCalculator
{
    LineItem CalculateCost(Parcel parcel);
}