// <copyright file="InvalidModelStateException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Crm.Shared.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// Represents errors that occur when <see cref="ModelStateDictionary">ModelState</see> is invalid.
    /// </summary>
    public class InvalidModelStateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidModelStateException"/> class.
        /// </summary>
        /// <param name="modelState">ModelState that failed to validate.</param>
        public InvalidModelStateException(ModelStateDictionary modelState)
        {
            this.ModelState = modelState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidModelStateException"/> class.
        /// </summary>
        /// <param name="modelState">ModelState that failed to validate.</param>
        /// <param name="validationFailures">A list of validation failures the model state should be populated with.</param>
        public InvalidModelStateException(ModelStateDictionary modelState, IEnumerable<ValidationFailure> validationFailures)
            : this(modelState)
        {
            foreach (var validationFailure in validationFailures)
            {
                this.ModelState.AddModelError(validationFailure.PropertyName, validationFailure.ErrorMessage);
            }
        }

        /// <summary>
        /// Gets the ModelState that failed to validate.
        /// </summary>
        public ModelStateDictionary ModelState { get; }
    }
}
