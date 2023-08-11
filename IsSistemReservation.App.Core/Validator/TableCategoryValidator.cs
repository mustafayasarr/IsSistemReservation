using FluentValidation;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using IsSistemReservation.App.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Validator
{
	public class TableCategoryValidator:AbstractValidator<TableCategoryRequestDto>
	{
        public TableCategoryValidator()
        {
			RuleFor(a => a.Code).NotEmpty().NotNull().WithError(ResponseMessageConstants.RequiredCode("Code"), ResponseMessageConstants.RequiredMessage("Code"));
			RuleFor(a => a.EnvironmentName).NotEmpty().NotNull().WithError(ResponseMessageConstants.RequiredCode("EnvironmentName"), ResponseMessageConstants.RequiredMessage("EnvironmentName"));

		}
	}
}
