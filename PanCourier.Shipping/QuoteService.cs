using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Enums;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping;

public class QuoteService : IQuoteService
{
    private readonly IParcelShippingCostCalculator _parcelShippingCostCalculator;

    public QuoteService(IParcelShippingCostCalculator parcelShippingCostCalculator)
    {
        _parcelShippingCostCalculator = parcelShippingCostCalculator;
    }

    public Quote CreateQuote(Consignment consignment)
    {
        var parcels = consignment.Parcels;

        var lineItems = new List<LineItem>();

        var parcelLineItems = parcels.Select(parcel => _parcelShippingCostCalculator.CalculateCost(parcel)).ToList();
        lineItems.AddRange(parcelLineItems);

        var totalCost = lineItems.Sum(l => l.Cost);

        if (consignment.OptForSpeedyShipping)
        {
            var speedyShippingLineItemType = new LineItem(LineItemType.SpeedyShipping, totalCost);
            totalCost *= 2;
            lineItems.Add(speedyShippingLineItemType);
        }

        return new Quote(lineItems, totalCost);
    }
}