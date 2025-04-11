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
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IRepository<Product> _productRepository;
       
        private readonly IUnitOfWork unitOfWork;

        public RemoveProductCommandHandler(IMapper mapper, IRepository<Product> productRepository = null, IUnitOfWork unitOfWork = null)
        {
            
            _productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsycn(request.id);
            return await unitOfWork.SaveChangesAsync();
            

        }
    }
}
