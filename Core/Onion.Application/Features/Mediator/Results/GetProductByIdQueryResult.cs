namespace Onion.Application.Features.Mediator.Results
{
   public record GetProductByIdQueryResult(Guid ProductId, string ProductName, Decimal Price, int Stock, Guid CategoryId, GetProductByIdQueryResult Category)
    {
    }
}
