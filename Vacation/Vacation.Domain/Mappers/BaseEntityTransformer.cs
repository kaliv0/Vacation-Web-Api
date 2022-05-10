using Vacation.Domain.Dtos;
using Vacation.Domain.Entities;

namespace Vacation.Domain.Mappers
{
    public static class BaseEntityTransformer<T>
        where T : BaseEntity
    {
        public static BaseDto ToBaseDto(T entity)
        {
            return new BaseDto(entity.Id, entity.Name);
        }
    }
}
