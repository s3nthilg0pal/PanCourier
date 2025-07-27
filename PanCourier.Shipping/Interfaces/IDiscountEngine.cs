using PanCourier.Shipping.Contracts;

namespace PanCourier.Shipping.Interfaces;

public interface IDiscountEngine
{
    IEnumerable<LineItem> Apply(IEnumerable<LineItem> parcels);
}