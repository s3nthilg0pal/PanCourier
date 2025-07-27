using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Enums;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping;

public class ParcelShippingCostCalculator : IParcelShippingCostCalculator
{
    public LineItem CalculateCost(Parcel parcel)
    {
        var parcelSize = parcel.GetSize();

        var lineItem = parcelSize switch
        {
            Size.Small => new LineItem(LineItemType.Small, 3),
            Size.Medium => new LineItem(LineItemType.Medium, 8),
            Size.Large => new LineItem(LineItemType.Large, 15),
            Size.ExtraLarge => new LineItem(LineItemType.ExtraLarge, 25)
        };

        return lineItem;
    }
}