﻿using Crm.Domains.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Domains.Request
{
    public class CreateCustomer : IRequest<Response.CreateCustomer>, ICustomer
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
