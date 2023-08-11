using FluentValidation;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos.Table;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Validator
{
	public class TableValidator:AbstractValidator<TableRequestDto>
	{
		public TableValidator()
        {
			RuleFor(a => a.TableName).NotEmpty().NotNull().WithError(ResponseMessageConstants.RequiredCode("TableName"), ResponseMessageConstants.RequiredMessage("TableName"));
			RuleFor(a => a.Capacity).GreaterThanOrEqualTo(1).WithError(ResponseMessageConstants.GreaterThanCode("Capacity"), ResponseMessageConstants.GreaterThanMessage("Capacity",1));
			RuleFor(a => a.TableCategoryId).NotEmpty().NotNull().WithError(ResponseMessageConstants.RequiredCode("TableCategoryId"), ResponseMessageConstants.RequiredMessage("TableCategoryId"));
			RuleFor(a => a.Number).GreaterThanOrEqualTo(0).WithError(ResponseMessageConstants.GreaterThanCode("Number"), ResponseMessageConstants.GreaterThanMessage("Number",0));

		}
	}
}
