using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos.TableCategory
{
    public class TableCategoryResultDto
    {
        public TableCategoryResultDto(Guid id, string code, string environmentName, DateTime createDate)
        {
            Id = id;
            Code = code;
            EnvironmentName = environmentName;
            CreateDate = createDate;
        }
        public TableCategoryResultDto()
        {

        }
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string EnvironmentName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
