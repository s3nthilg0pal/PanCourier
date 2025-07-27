using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping.Discounts;

/// <summary>
/// Every 4th small parcel in an order is free!
/// </summary>
public class SmallParcelDiscountRule : IDiscountRule
{
    public void Evaluate(IEnumerable<LineItem> parcels)
    {
        // Filter small parcels
        // Order by costs
        // Create a batch of 4 and iterate
        // Get the minimum cost of 4 and add the batch to the collection
        throw new NotImplementedException();
    }
}