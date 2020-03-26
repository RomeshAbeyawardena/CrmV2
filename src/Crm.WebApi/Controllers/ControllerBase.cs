using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.WebApi.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public ControllerBase(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }

        public IMediator Mediator { get; }
        public IMapper Mapper { get; }

        void EnsureValidModelState()
        {
            if(ModelState.IsValid)
                return;

            throw new InvalidModelStateFilterConvention();
        }
    }
}
