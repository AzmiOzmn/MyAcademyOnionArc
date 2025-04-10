using AutoMapper;
using Onion.Application.Features.CQRS.Commends;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.CQRS.Handlers
{
   public class RemoveCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(RemoveCategoryCommand cmd)
        {
            await repository.DeleteAsycn(cmd.id);
            return await unitOfWork.SaveChangesAsync();

        }
    }
}
