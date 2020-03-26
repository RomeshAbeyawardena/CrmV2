using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crm.Shared
{
    public abstract class ResultRequestHandler<TRequest, TResponse, TResult> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse<TResult>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public TResponse Success(TResult result)
        {
            var response = (IResponse<TResult>)Activator.CreateInstance<TResponse>();

            response.Result = result;
            response.IsSuccessful = true;
            return (TResponse)response;
        }
    }
}
