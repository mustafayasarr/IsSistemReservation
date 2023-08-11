using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IsSistemReservation.App.Core.Services.TableCategory
{
	public class TableCategoryService : ITableCategoryService
	{
		private IUnitOfWork _unitOfWork;
		private readonly ILogger<TableCategoryService> _logger;

		public TableCategoryService(IUnitOfWork unitOfWork, ILogger<TableCategoryService> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}
		public async Task<BaseResponseResult<List<TableCategoryResultDto>>> GetTableCategories()
		{
			var response = new BaseResponseResult<List<TableCategoryResultDto>>();
			try
			{
				response.Result = await _unitOfWork.TableCategoryRepository.Table.Select(a => new TableCategoryResultDto(a.Id, a.Code, a.EnvironmentName, a.CreatedDate.ToLocalTime())).ToListAsync();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				response.Errors.Add(new Error(ResponseMessageConstants.AnErrorOccurredCode, ResponseMessageConstants.AnErrorOccurred));
			}
			return response;
		}

		public async Task<BaseResponseResult> CreateTableCategories(TableCategoryRequestDto dto)
		{
			var response = new BaseResponseResult();

			try
			{
				var getHotel = await _unitOfWork.TableCategoryRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.IsActive && x.Code == dto.Code);
				if (getHotel!=null)
				{
					response.Errors.Add(new Error(ResponseMessageConstants.AllreadyRecordDataCode, ResponseMessageConstants.AllreadyRecordData));
					return response;
				}
				_unitOfWork.TableCategoryRepository.Add(new Domain.Models.Entities.TableCategory(dto.Code, dto.EnvironmentName));
				await _unitOfWork.CompleteAsync();

			}
			catch (Exception ex)
			{
				await _unitOfWork.CompleteAsync(false);
				_logger.LogError(ex, ex.Message);
				response.Errors.Add(new Error(ResponseMessageConstants.AnErrorOccurredCode, ResponseMessageConstants.AnErrorOccurred));
			}
			return response;
		}
	}
}
