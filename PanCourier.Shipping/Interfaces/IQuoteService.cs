using PanCourier.Shipping.Contracts;

namespace PanCourier.Shipping.Interfaces;

public interface IQuoteService
{
    Quote CreateQuote(Consignment consignment);
}