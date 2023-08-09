using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Services.TableCategory
{
    public interface ITableCategoryService
	{
		Task<BaseResponseResult<List<TableCategoryResultDto>>> GetTableCategories();
		Task<BaseResponseResult> CreateTableCategories(TableCategoryRequestDto tableCategoryDto);
	}
}
