using PanCourier.Shipping.Contracts;
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

        var lineItems = parcels.Select(parcel => _parcelShippingCostCalculator.CalculateCost(parcel)).ToList();

        var totalCost = lineItems.Sum(l => l.Cost);

        return new Quote(lineItems, totalCost);
    }
}