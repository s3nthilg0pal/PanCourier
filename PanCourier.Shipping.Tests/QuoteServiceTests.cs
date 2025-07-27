using Moq;
using PanCourier.Shipping.Contracts;
using PanCourier.Shipping.Enums;
using PanCourier.Shipping.Interfaces;

namespace PanCourier.Shipping.Tests;

public class QuoteServiceTests
{
    private QuoteService _service;
    private Mock<IParcelShippingCostCalculator> _parcelCalculatorMock;

    [SetUp]
    public void Setup()
    {
        _parcelCalculatorMock = new Mock<IParcelShippingCostCalculator>();
        _service = new QuoteService(_parcelCalculatorMock.Object);
    }

    [Test]
    public void ShouldCreateQuoteWithExpectedLineItemsAndTotalCost()
    {
        // Arrange
        var parcels = new List<Parcel>
        {
            new Parcel(5, 5, 5),
            new Parcel(20, 20, 20),
            new Parcel(70, 70, 70)
        };
        var consignment = new Consignment(parcels);

        // Setup mocks for each parcel
        _parcelCalculatorMock.Setup(pc => pc.CalculateCost(parcels[0]))
            .Returns(new LineItem(LineItemType.Small, 3));
        _parcelCalculatorMock.Setup(pc => pc.CalculateCost(parcels[1]))
            .Returns(new LineItem(LineItemType.Medium, 8));
        _parcelCalculatorMock.Setup(pc => pc.CalculateCost(parcels[2]))
            .Returns(new LineItem(LineItemType.Large, 15));

        // Act
        var quote = _service.CreateQuote(consignment);

        // Assert
        Assert.That(quote, Is.Not.Null);
        Assert.That(quote.LineItems.Count, Is.EqualTo(3));
        Assert.That(quote.TotalCost, Is.EqualTo(3 + 8 + 15));

        var lineItems = quote.LineItems.ToArray();

        // Verify line items
        Assert.That(lineItems[0].Type, Is.EqualTo(LineItemType.Small));
        Assert.That(lineItems[1].Type, Is.EqualTo(LineItemType.Medium));
        Assert.That(lineItems[2].Type, Is.EqualTo(LineItemType.Large));

        // Verify interactions
        _parcelCalculatorMock.Verify(pc => pc.CalculateCost(It.IsAny<Parcel>()), Times.Exactly(3));
    }

    [Test]
    public void ShouldDoubleTotalCostWhenOptForSpeedyShipping()
    {
        // Arrange
        var parcels = new List<Parcel>
        {
            new Parcel(5, 5, 5),
        };
        var optForSpeedyShipping = true;
        var consignment = new Consignment(parcels, optForSpeedyShipping);

        _parcelCalculatorMock.Setup(pc => pc.CalculateCost(parcels[0]))
            .Returns(new LineItem(LineItemType.Small, 3));

        // Act
        var quote = _service.CreateQuote(consignment);

        // Assert
        Assert.That(quote, Is.Not.Null);
        Assert.That(quote.LineItems.Count, Is.EqualTo(2));
        Assert.That(quote.TotalCost, Is.EqualTo(6));

        var lineItems = quote.LineItems.ToArray();

        // Verify line items
        Assert.That(lineItems[0].Type, Is.EqualTo(LineItemType.Small));
        Assert.That(lineItems[1].Type, Is.EqualTo(LineItemType.SpeedyShipping));
    }

}