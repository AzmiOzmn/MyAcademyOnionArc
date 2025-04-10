using AutoMapper;
using Onion.Application.Features.CQRS.Queries;
using Onion.Application.Features.CQRS.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.CQRS.Handlers
{
   public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var category = await repository.GetByIdAsycn(query.id);
            return _mapper.Map<GetCategoryByIdQueryResult>(category);
        }

    }
}
