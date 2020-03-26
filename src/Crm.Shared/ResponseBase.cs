using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
namespace Crm.Shared
{
    public abstract class ResponseBase<TResult> : IResponse<TResult>
    {
        public bool IsSuccessful { get; set; }

        public TResult Result { get; set; }

        public IEnumerable<ValidationFailure> Errors { get; set; }

        public bool IsSuccess => Result != null && IsSuccessful;
    }

    public interface IResponse<TResult>
    {
        bool IsSuccessful { get; set; }

        TResult Result { get; set; }

        IEnumerable<ValidationFailure> Errors { get; set; }

        public bool IsSuccess { get; }
    } 
}
