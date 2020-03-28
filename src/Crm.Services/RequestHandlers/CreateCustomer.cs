// <copyright file="CreateCustomer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Crm.Services.RequestHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Crm.Contracts.Services;
    using Crm.Domains.Dto;
    using Crm.Shared;
    using CreateCustomerRequest = Crm.Domains.Request.CreateCustomer;
    using CreateCustomerResponse = Crm.Domains.Response.CreateCustomer;

    /// <inheritdoc/>
    public class CreateCustomer : ResultRequestHandler<CreateCustomerRequest, CreateCustomerResponse, Customer>
    {
        private readonly ICustomerService customerService;

        public CreateCustomer(IMapper mapper, ICustomerService customerService)
            : base(mapper)
        {
            this.customerService = customerService;
        }

        /// <inheritdoc/>
        public override async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = Mapper.Map<Customer>(request);

            var savedCustomer = customerService.SaveCustomer(customer, cancellationToken);
            return Success(customer);
        }
    }
}
