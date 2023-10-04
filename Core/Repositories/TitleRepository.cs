using EFCFExcercise.Data;
using EFCFExcercise.Models;
using EFCFExcercise.Models.Dto.Title;
using EFCFExcercise.Mapper;
using Microsoft.EntityFrameworkCore;

namespace EFCFExcercise.Core.Repositories
{
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(EFCFExcerciseContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<bool> AddAsync(TitleDto titleDto)
        {
            Title newTitle = TitleMapper.MapToTitle(titleDto);
            await this.AddAsync(newTitle);
            return true;
        }

        public async Task<bool> UpdateAsync(int id, TitleDto titleDto)
        {
            Title? title = await this.GetAsync(id);
            if (title == null)
            {
                throw new DbUpdateConcurrencyException();
            }
            title = TitleMapper.AlignToTitle(title, titleDto);
            await this.Update(title);
            return true;
        }
    }
}
