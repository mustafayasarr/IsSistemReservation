using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Gateways.NotificationService
{
	public class NotificationGateway : BaseService,INotificationGateway
	{
		public NotificationGateway(IConfiguration configuration, IRestService restService) : base(restService)
		{
			BaseAddress = configuration["ServiceUrls:ReportService"];

		}

		public async Task<BaseResponseResult> SendCustomerReservationMail(ReservationResultDto request)
		{
			return await _restService.PostMethodAsync<BaseResponseResult>(request, BaseAddress + GatewayUrls.SendCustomerReservationMail);
		}

	
	}
}
