using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using IsSistemReservation.App.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Validator
{
	public class UseCustomErrorModelInterceptor : IValidatorInterceptor
	{
		public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
		{
			var failures = result.Errors
			.Select(error => new ValidationFailure(error.PropertyName, SerializeError(error)));

			return new ValidationResult(failures);
		}

		public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
		{

			return commonContext;
		}
		private static string SerializeError(ValidationFailure failure)
		{
			var error = new Error(failure.ErrorCode, failure.ErrorMessage);
			return JsonSerializer.Serialize(error);
		}
	}
}
