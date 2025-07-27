using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Enums;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping;

public class ParcelShippingCostCalculator : IParcelShippingCostCalculator
{
    private readonly Dictionary<Size, ProductOption> _productOptions = new()
    {
        { Size.Small, new ProductOption(Size.Small, 3, 1, OverWeightSurcharge) },
        { Size.Medium, new ProductOption(Size.Medium, 8, 3, OverWeightSurcharge) },
        { Size.Large, new ProductOption(Size.Large, 15, 6, OverWeightSurcharge) },
        { Size.ExtraLarge, new ProductOption(Size.ExtraLarge, 25, 10, OverWeightSurcharge) },
        { Size.Heavy, new ProductOption(Size.Heavy, 50, 50, HeavyWeightSurcharge) },
    };

    private const double OverWeightSurcharge = 2;
    private const double HeavyWeightSurcharge = 1;


    public LineItem CalculateCost(Parcel parcel)
    {
        var parcelSize = parcel.GetSize();

        var productOption = _productOptions[parcelSize];

        var cost = productOption.BaseCost;
        var weightLimit = productOption.WeightLimit;

        var parcelWeight = parcel.Weight;

        if (parcelWeight > weightLimit)
        {
            var weightToBill = parcelWeight - weightLimit;
            cost += weightToBill * productOption.WeightSurcharge;
        }

        var lineItem = parcelSize switch
        {
            Size.Small => new LineItem(LineItemType.Small, cost),
            Size.Medium => new LineItem(LineItemType.Medium, cost),
            Size.Large => new LineItem(LineItemType.Large, cost),
            Size.ExtraLarge => new LineItem(LineItemType.ExtraLarge, cost),
            Size.Heavy => new LineItem(LineItemType.Heavy, cost)
        };

        return lineItem;
    }
}

internal record ProductOption(Size Size, double BaseCost, int WeightLimit, double WeightSurcharge);