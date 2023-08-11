using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Validator
{
	public static class ValidatorExtensions
	{
		public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string errorCode, string errorMessage)
		{
			return rule
				.WithErrorCode(errorCode)
				.WithMessage(errorMessage);
		}
	}
}
