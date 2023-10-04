using EFCFExcercise.Models;
using EFCFExcercise.Models.Dto.Title;

namespace EFCFExcercise.Core
{
    public interface ITitleRepository : IGenericRepository<Title>
    {
        public Task<bool> AddAsync(TitleDto titleDto);
        public Task<bool> UpdateAsync(int id, TitleDto titleDto);   
    }
}
