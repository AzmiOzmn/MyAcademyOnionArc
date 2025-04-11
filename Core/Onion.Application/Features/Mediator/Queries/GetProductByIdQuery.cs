using MediatR;
using Onion.Application.Features.Mediator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Mediator.Queries
{
   public record GetProductByIdQuery(Guid id) : IRequest<GetProductByIdQueryResult>
    {
        public Guid Id { get; init; } = id;
    }
}
