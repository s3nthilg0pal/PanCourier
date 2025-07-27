using PanCourier.Shipping.Enums;

namespace PanCourier.Shipping.Contracts;

public record Parcel(double LengthCm, double WidthCm, double HeightCm)
{
    public double LengthCm { get; set; } = LengthCm;
    public double WidthCm { get; set; } = WidthCm;
    public double HeightCm { get; set; } = HeightCm;

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