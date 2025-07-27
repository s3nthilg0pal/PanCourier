using PanCourier.Shipping.Enums;

namespace PanCourier.Shipping.Contracts;

public record LineItem(LineItemType Type, double Cost);