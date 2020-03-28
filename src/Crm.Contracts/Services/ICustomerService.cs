// <copyright file="ICustomerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Crm.Contracts.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Crm.Domains.Data;

    /// <summary>
    /// Represents a customer service to carry out CRUD operations on a customer domain object.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Ability to save a customer to a datasource.
        /// </summary>
        /// <param name="customer">Customer to save.</param>
        /// <param name="cancellationToken">CancellationToken to abort the task.</param>
        /// <returns>Returns saved customer.</returns>
        Task<Customer> SaveCustomer(Customer customer, CancellationToken cancellationToken);
    }
}
