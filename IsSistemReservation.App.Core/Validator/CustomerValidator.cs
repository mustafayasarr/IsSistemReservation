using FluentValidation;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Validator
{
	public class CustomerValidator:AbstractValidator<CustomerRequestDto>
	{
        public CustomerValidator()
        {
			RuleFor(a => a.Name).NotEmpty().NotEmpty().WithError(ResponseMessageConstants.RequiredCode("'Name'"), ResponseMessageConstants.RequiredMessage("'Name'"));
			RuleFor(a => a.LastName).NotEmpty().NotEmpty().WithError(ResponseMessageConstants.RequiredCode("'LastName'"), ResponseMessageConstants.RequiredMessage("'LastName'"));
			RuleFor(a => a.TelNo).NotEmpty().NotEmpty().WithError(ResponseMessageConstants.RequiredCode("'TelNo'"), ResponseMessageConstants.RequiredMessage("'TelNo'"));
			RuleFor(a => a.Email).NotEmpty().NotEmpty().WithError(ResponseMessageConstants.RequiredCode("'Email'"), ResponseMessageConstants.RequiredMessage("'Email'"));

		}
	}
}
