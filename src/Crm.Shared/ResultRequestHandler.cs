// <copyright file="ResultRequestHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Crm.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Crm.Shared.Contracts;
    using FluentValidation.Results;
    using MediatR;

    /// <summary>
    /// Represents a <see cref="IRequestHandler{TRequest, TResponse}">RequestHandler</see> that returns a <see cref="TResult">result</see>.
    /// </summary>
    /// <typeparam name="TRequest"><see cref="IRequest{TResponse}">Request</see> to handle.</typeparam>
    /// <typeparam name="TResponse"><see cref="IResponse{TResult}">Response</see> to return.</typeparam>
    /// <typeparam name="TResult"><see cref="TResult">Result</see> type that return.</typeparam>
    public abstract class ResultRequestHandler<TRequest, TResponse, TResult> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse<TResult>
    {
        protected ResultRequestHandler(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets an instance of the AutoMapper utility.
        /// </summary>
        public IMapper Mapper { get; }

        /// <inheritdoc/>
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Creates an instance of a successful <see cref="IResponse{TResult}">response</see> containing a result.
        /// </summary>
        /// <param name="result">Result type to returns. </param>
        /// <returns>Returns a successful response object containing a result.</returns>
        public TResponse Success(TResult result)
        {
            var response = (IResponse<TResult>)Activator.CreateInstance<TResponse>();

            response.Result = result;
            response.IsSuccessful = true;
            return (TResponse)response;
        }

        /// <summary>
        /// Creates an instance failed <see cref="IResponse{TResult}">response</see>.
        /// </summary>
        /// <param name="validationFailures">A list of <see cref="ValidationFailure">errors</see> preventing the response from being successful.</param>
        /// <returns>Returns a successful response object containing a result.</returns>
        public TResponse Failed(IEnumerable<ValidationFailure> validationFailures)
        {
            var response = (IResponse<TResult>)Activator.CreateInstance<TResponse>();

            response.Errors = validationFailures;
            response.IsSuccessful = false;
            return (TResponse)response;
        }
    }
}
