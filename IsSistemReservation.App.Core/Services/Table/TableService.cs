using IsSistemReservation.App.Core.Services.TableCategory;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.Table;
using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Services.Table
{
	public class TableService : ITableService
	{
		private IUnitOfWork _unitOfWork;
		private readonly ILogger<TableService> _logger;
		public TableService(IUnitOfWork unitOfWork, ILogger<TableService> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}
		public async Task<BaseResponseResult<List<TableResultDto>>> GetAllTables()
		{
			var response = new BaseResponseResult<List<TableResultDto>>();

			try
			{
				response.Result = await _unitOfWork.TableRepository.Table.Include(a => a.TableCategory).Where(a => a.IsActive).Select(c => new TableResultDto(c.TableName, c.Number, c.Capacity, new TableCategoryResultDto(c.TableCategory.Id, c.TableCategory.Code, c.TableCategory.EnvironmentName, c.TableCategory.CreatedDate), c.CreatedDate)).ToListAsync();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);
			}
			return response;
		}

		public async Task<BaseResponseResult<List<TableResultDto>>> GetAvailableTables()
		{
			var response = new BaseResponseResult<List<TableResultDto>>();

			try
			{
				response.Result = await _unitOfWork.TableRepository.Table.Include(a => a.TableCategory).Include(a => a.Reservations).Where(a => a.IsActive && !a.Reservations.Any(x => x.ReservationDate.Day == DateTime.Now.Day && x.IsActive)).Select(c => new TableResultDto(c.TableName, c.Number, c.Capacity, new TableCategoryResultDto(c.TableCategory.Id, c.TableCategory.Code, c.TableCategory.EnvironmentName, c.TableCategory.CreatedDate), c.CreatedDate)).ToListAsync();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);
			}
			return response;
		}

		public async Task<BaseResponseResult> CreateTable(TableRequestDto dto)
		{
			var response = new BaseResponseResult();

			try
			{
				if (_unitOfWork.TableRepository.Where(a => a.TableCategoryId == dto.TableCategoryId && a.Number == dto.Number && a.IsActive).Any())
				{

					response.Errors.Add(ResponseMessageConstants.AllreadyRecordData);
					return response;
				}
				_unitOfWork.TableRepository.Add(new Domain.Models.Entities.Table(dto.TableName, dto.Number, dto.Capacity, dto.TableCategoryId));
				await _unitOfWork.CompleteAsync();

			}
			catch (Exception ex)
			{
				await _unitOfWork.CompleteAsync(false);
				_logger.LogError(ex, ex.Message);
				response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);
			}
			return response;
		}
	}
}
