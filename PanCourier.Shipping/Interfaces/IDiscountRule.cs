using PanCourier.Shipping.Contracts;

namespace PanCourier.Shipping.Interfaces;

public interface IDiscountRule
{
    // Create a new type that returns discount and lineitems
    void Evaluate(IEnumerable<LineItem> parcels);
}