using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Enums;

namespace PanCourier.Shipping.Tests;

public class ParcelShippingCostCalculatorTests
{
    private ParcelShippingCostCalculator _parcelShippingCostCalculator; 

    [SetUp]
    public void Setup()
    {
        _parcelShippingCostCalculator = new ParcelShippingCostCalculator();
    }

    [TestCase(5, 5, 5, LineItemType.Small, 3)]
    [TestCase(20, 20, 20, LineItemType.Medium, 8)]
    [TestCase(70, 70, 70, LineItemType.Large, 15)]
    [TestCase(100, 80, 80, LineItemType.ExtraLarge, 25)]
    public void ShouldReturnExpectedCostForValidParcelSizes(
        double length, double width, double height, LineItemType expectedSize, double expectedCost)
    {
        // Arrange
        var parcel = new Parcel(length, width, height);

        // Act
        var result = _parcelShippingCostCalculator.CalculateCost(parcel);

        // Assert
        Assert.That(result.Type, Is.EqualTo(expectedSize));
        Assert.That(result.Cost, Is.EqualTo(expectedCost));
    }

    [TestCase(10, 10, 10, LineItemType.Medium, 8)]
    [TestCase(50, 50, 50, LineItemType.Large, 15)]
    [TestCase(100, 99, 99, LineItemType.ExtraLarge, 25)]
    public void ShouldHandleBoundaryValuesCorrectly(
        double length, double width, double height, LineItemType expectedSize, double expectedCost)
    {
        // Arrange
        var parcel = new Parcel(length, width, height );

        // Act
        var result = _parcelShippingCostCalculator.CalculateCost(parcel);

        // Assert
        Assert.That(result.Type, Is.EqualTo(expectedSize));
        Assert.That(result.Cost, Is.EqualTo(expectedCost));
    }
}