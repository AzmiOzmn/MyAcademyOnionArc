using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.CQRS.Commends
{
   public record RemoveCategoryCommand(Guid id)
    {
    }
}
