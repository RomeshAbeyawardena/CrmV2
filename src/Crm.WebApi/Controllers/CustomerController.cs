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
        private IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> CreateCustomer(CreateCustomerViewModel customerViewModel)
        {
            
            return Ok();
        }
    }
}
