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
            .Returns(new LineItem(Size.Small, 3));
        _parcelCalculatorMock.Setup(pc => pc.CalculateCost(parcels[1]))
            .Returns(new LineItem(Size.Medium, 8));
        _parcelCalculatorMock.Setup(pc => pc.CalculateCost(parcels[2]))
            .Returns(new LineItem(Size.Large, 15));

        // Act
        var quote = _service.CreateQuote(consignment);

        // Assert
        Assert.That(quote, Is.Not.Null);
        Assert.That(quote.LineItems.Count, Is.EqualTo(3));
        Assert.That(quote.TotalCost, Is.EqualTo(3 + 8 + 15));

        var lineItems = quote.LineItems.ToArray();

        // Verify line items
        Assert.That(lineItems[0].Size, Is.EqualTo(Size.Small));
        Assert.That(lineItems[1].Size, Is.EqualTo(Size.Medium));
        Assert.That(lineItems[2].Size, Is.EqualTo(Size.Large));

        // Verify interactions
        _parcelCalculatorMock.Verify(pc => pc.CalculateCost(It.IsAny<Parcel>()), Times.Exactly(3));
    }

}