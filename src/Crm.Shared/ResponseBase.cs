// <copyright file="ResponseBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Crm.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Crm.Shared.Contracts;
    using FluentValidation.Results;

    /// <summary>
    /// Represents a Response Base.
    /// </summary>
    /// <typeparam name="TResult">Return type.</typeparam>
    public abstract class ResponseBase<TResult> : IResponse<TResult>
    {
        /// <inheritdoc/>
        public bool IsSuccessful { get; set; }

        /// <inheritdoc/>
        public TResult Result { get; set; }

        /// <inheritdoc/>
        public IEnumerable<ValidationFailure> Errors { get; set; }

        /// <inheritdoc/>
        public bool IsSuccess => this.Result != null && this.IsSuccessful;
    }
}
