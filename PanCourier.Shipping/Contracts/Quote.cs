namespace PanCourier.Shipping.Contracts;

public record Quote(ICollection<LineItem> LineItems, double TotalCost);