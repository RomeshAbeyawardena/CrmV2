using AutoMapper;
using Crm.Domains.Request;
using Crm.Domains.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.WebApi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<IActionResult> CreateCustomer(CreateCustomerViewModel customerViewModel)
        {
            var request = mapper.Map<CreateCustomer>(customerViewModel);
            var response = await mediator.Send(request);

            if(response.IsSuccess)
                return Ok(response.Result);

            return BadRequest(response.Errors);
        }
    }
}
