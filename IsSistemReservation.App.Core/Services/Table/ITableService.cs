using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Services.Table
{
	public interface ITableService
	{
		Task<BaseResponseResult<List<TableResultDto>>> GetAvailableTables();
		Task<BaseResponseResult<List<TableResultDto>>> GetAllTables();
		Task<BaseResponseResult> CreateTable(TableRequestDto dto);
	}
}
