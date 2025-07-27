using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping.Discounts;

/// <summary>
/// Every 5th parcel in an order is free!
/// </summary>
public class MixedParcelDiscountRule : IDiscountRule
{
    public void Evaluate(IEnumerable<LineItem> parcels)
    {
        // Order by costs
        // Create a batch of 5 and iterate
        // Get the minimum cost of batch and add the batch to the collection
        throw new NotImplementedException();
    }
}