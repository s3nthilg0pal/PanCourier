using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Enums;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping;

public class ParcelShippingCostCalculator : IParcelShippingCostCalculator
{
    public LineItem CalculateCost(Parcel parcel)
    {
        var parcelSize = parcel.GetSize();

        var cost = parcelSize switch
        {
            Size.Small => 3,
            Size.Medium => 8,
            Size.Large => 15,
            Size.ExtraLarge => 25,
            _ => 0
        };

        return new LineItem(parcelSize, cost);
    }
}