namespace Onion.Application.Features.Mediator.Results
{
   public record GetProductQueryResult(Guid ProductId,string ProductName,Decimal Price,int Stock,Guid CategoryId,GetProductQueryResult Category)
    {
    }
}
