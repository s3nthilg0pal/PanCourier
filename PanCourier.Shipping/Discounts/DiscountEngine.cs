using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping.Discounts;

public class DiscountEngine : IDiscountEngine
{
    private readonly ICollection<IDiscountRule> _rules;

    public DiscountEngine(ICollection<IDiscountRule> rules)
    {
        _rules = rules;
    }

    public IEnumerable<LineItem> Apply(IEnumerable<LineItem> parcels)
    {
        // Create a temporary lineitems to keep track of the discounted items
        // Iterate the rules
        // Order matters - Small, Medium, Mixed rules
        // at the end of every iteration, remove the lineitems from the temp list
        // Iterate till the temp list is empty
        // Return a list of lineitem with LineItemType.Discount and with negative cost value

        return Array.Empty<LineItem>();
    }
}