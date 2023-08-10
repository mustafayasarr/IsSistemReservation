using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Gateways
{
	public class BaseService
	{
		protected string BaseAddress;
		protected string ServiceSecret;
		protected readonly IRestService _restService;
		public BaseService(IRestService restService)
		{
			_restService = restService;
		}
	
	}
}
