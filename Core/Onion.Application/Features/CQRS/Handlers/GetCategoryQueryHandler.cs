using AutoMapper;
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
   public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsycn();
            return _mapper.Map<List<GetCategoryQueryResult>>(values);
        }
    }
}
