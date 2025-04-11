using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Mediator.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {

        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IMapper mapper, IRepository<Product> productRepository = null, IUnitOfWork unitOfWork = null)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);  
             _productRepository.Update(product);
            return await unitOfWork.SaveChangesAsync();


        }
    }
}
