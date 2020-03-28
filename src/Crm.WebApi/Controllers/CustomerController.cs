using AutoMapper;
using Crm.Domains.Dto;
using Crm.Domains.Request;
using Crm.Domains.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crm.WebApi.Controllers
{
    public class CustomerController : ControllerBase
    {
        public CustomerController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper)
        {

        }

        public async Task<IActionResult> CreateCustomer(CreateCustomerViewModel customerViewModel, CancellationToken cancellationToken)
        {
            EnsureValidModelState();

            var request = Mapper.Map<CreateCustomer>(customerViewModel);
            var response = await Mediator.Send(request, cancellationToken);

            return await HandleAsync(response, cancellationToken);
        }
    }
}
