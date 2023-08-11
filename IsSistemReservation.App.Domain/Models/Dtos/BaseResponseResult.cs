using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos
{
	public class BaseResponseResult<TData> where TData : class
	{
		public BaseResponseResult()
		{
			Errors = new List<Error>();
		}

		public bool HasError => Errors.Any();
		public List<Error> Errors { get; set; }
		public TData Result { get; set; }
	}
	public class BaseResponseResult
	{
		public BaseResponseResult()
		{
			Errors = new List<Error>();
		}

		public bool HasError => Errors.Any();
		public List<Error> Errors { get; set; }

	}
	public class Error
	{
        public Error(string errorCode,string errorMessage)
        {
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
        }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

    }
}
