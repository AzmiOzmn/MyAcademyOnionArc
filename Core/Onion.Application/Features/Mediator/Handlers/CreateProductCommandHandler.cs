using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Mediator.Handlers
{
    class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,bool>
    {

        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IMapper mapper, IRepository<Product> productRepository = null, IUnitOfWork unitOfWork = null)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
           var product = _mapper.Map<Product>(request);
           await _productRepository.CreateAsycn(product);
           return await unitOfWork.SaveChangesAsync();
        



        }
    }
}
