using EFCFExcercise.Models;
using EFCFExcercise.Models.Dto.Title;

namespace EFCFExcercise.Mapper
{
    public class TitleMapper
    {
        public static TitleDto MapToDto(Title title)
        {
            return new TitleDto
            {
                TitleDescription = title.TitleDescription
            };
        }

        public static Title MapToTitle(TitleDto titleDto)
        {
            return new Title
            {
                TitleDescription = titleDto.TitleDescription
            };
        }

        public static Title AlignToTitle(Title title, TitleDto titleDto)
        {
            title.TitleDescription = titleDto.TitleDescription;
            return title;
        }   
    }
}
