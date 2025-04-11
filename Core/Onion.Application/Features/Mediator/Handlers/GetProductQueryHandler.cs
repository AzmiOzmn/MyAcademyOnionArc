using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Queries;
using Onion.Application.Features.Mediator.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Mediator.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IMapper mapper, IRepository<Product> productRepository = null)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request,CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsycn();
            return _mapper.Map<List<GetProductQueryResult>>(products);
        }
    }

}

