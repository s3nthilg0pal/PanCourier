using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Enums;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping;

public class QuoteService : IQuoteService
{
    private readonly IParcelShippingCostCalculator _parcelShippingCostCalculator;
    private readonly IDiscountEngine _discountEngine;

    public QuoteService(IParcelShippingCostCalculator parcelShippingCostCalculator, IDiscountEngine discountEngine)
    {
        _parcelShippingCostCalculator = parcelShippingCostCalculator;
        _discountEngine = discountEngine;
    }

    public Quote CreateQuote(Consignment consignment)
    {
        var parcels = consignment.Parcels;

        var lineItems = new List<LineItem>();

        var parcelLineItems = parcels.Select(parcel => _parcelShippingCostCalculator.CalculateCost(parcel)).ToList();
        lineItems.AddRange(parcelLineItems);

        var totalCost = lineItems.Sum(l => l.Cost);

        var discounts = _discountEngine.Apply(lineItems);
        if (discounts.Any())
        {
            lineItems.AddRange(discounts);

            var totalDiscount = discounts.Sum(x => x.Cost);

            totalCost += totalDiscount;
        }

        if (consignment.OptForSpeedyShipping)
        {
            var speedyShippingLineItemType = new LineItem(LineItemType.SpeedyShipping, totalCost);
            totalCost *= 2;
            lineItems.Add(speedyShippingLineItemType);
        }

        return new Quote(lineItems, totalCost);
    }
}