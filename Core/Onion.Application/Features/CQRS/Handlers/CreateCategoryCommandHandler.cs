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
   public class CreateCategoryCommandHandler(IRepository<Category> repository,IMapper mapper,IUnitOfWork unitOfWork)
    {

        public async Task<bool> Handle(CreateCategoryCommand command)
        {
            var category = mapper.Map<Category>(command);
            await repository.CreateAsycn(category);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
