using FluentValidation;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Validator
{
	public class ReservationValidator:AbstractValidator<ReservationRequestDto>
	{
        public ReservationValidator()
        {
            RuleFor(a=>a.NumberOfGuests).GreaterThanOrEqualTo(1).WithError(ResponseMessageConstants.GreaterThanCode("NumberOfGuests"),ResponseMessageConstants.GreaterThanMessage("NumberOfGuests",1));
            RuleFor(a=>a.CustomerId).NotEmpty().NotNull().WithError(ResponseMessageConstants.RequiredCode("CustomerId"), ResponseMessageConstants.RequiredMessage("CustomerId"));
            RuleFor(a=>a.ReservationDate).NotEmpty().NotNull().WithError(ResponseMessageConstants.RequiredCode("ReservationDate"), ResponseMessageConstants.RequiredMessage("ReservationDate"));
        }
    }
}
