using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Constants
{
	public static class ResponseMessageConstants
	{
		public const string AnErrorOccurredCode = "an_error_occured";
		public const string AnErrorOccurred = "Bir hata oluştu. Lütfen tekrar deneyiniz.";

		public const string NoRecordCustomerCode = "no_record_customer";
		public const string NoRecordCustomer = "Müşteri kaydı bulunmamaktadır.";

		public const string NoRecordTableCapacityCode = "no_record_table";
		public const string NoRecordTableCapacity = "Üzgünüz, uygun masa bulunamadı.";

		public const string AllreadyRecordDataCode = "allready_record_data";
		public const string AllreadyRecordData = "Böyle bir kayıt bulunmaktadır.";

		public static string RequiredCode(string fieldName) => $"{fieldName}_required";
		public static string RequiredMessage(string fieldName) => $"{fieldName} alanı gereklidir.";

		public static string GreaterThanCode(string fieldName) => $"{fieldName}_greater_than";
		public static string GreaterThanMessage(string fieldName,int number) => $"{fieldName} alanı {number} sayısından büyük olması gereklidir.";

	}
}
