using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Mediator.Commands
{
   public record RemoveProductCommand(Guid id) : IRequest<bool>;
    
  
}
