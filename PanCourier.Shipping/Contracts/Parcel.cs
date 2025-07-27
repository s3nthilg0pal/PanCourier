using PanCourier.Shipping.Enums;

namespace PanCourier.Shipping.Contracts;

public record Parcel(double LengthCm, double WidthCm, double HeightCm, double Weight = 0)
{
    public Size GetSize()
    {
        if (LengthCm >= 100 || WidthCm >= 100 || HeightCm >= 100)
            return Size.ExtraLarge;

        if (LengthCm < 10 && WidthCm < 10 && HeightCm < 10)
            return Size.Small;

        if (LengthCm < 50 && WidthCm < 50 && HeightCm < 50)
            return Size.Medium;
        
        return Size.Large;
    }

}