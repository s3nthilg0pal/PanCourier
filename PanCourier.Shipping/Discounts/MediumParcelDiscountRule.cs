using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping.Discounts;

/// <summary>
/// Every 3rd medium parcel in an order is free
/// </summary>
public class MediumParcelDiscountRule : IDiscountRule
{
    public void Evaluate(IEnumerable<LineItem> parcels)
    {
        // Filter medium parcels
        // Order by costs
        // Create a batch of 3 and iterate
        // Get the minimum cost of batch and add the batch to the collection
        throw new NotImplementedException();
    }
}