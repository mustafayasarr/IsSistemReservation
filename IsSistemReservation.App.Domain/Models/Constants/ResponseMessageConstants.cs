using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Constants
{
	public static class ResponseMessageConstants
	{
		public const string AnErrorOccurred = "Bir hata oluştu. Lütfen tekrar deneyiniz.";
		public const string NoRecordCustomer = "Müşteri kaydı bulunmamaktadır.";
		public const string NoRecordTableCapacity = "Üzgünüz, uygun masa bulunamadı.";
		public const string AllreadyRecordData = "Böyle bir kayıt bulunmaktadır.";
	}
}
