using EFCFExcercise.Models;
using EFCFExcercise.Models.Dto.Staff;

namespace EFCFExcercise.Mapper
{
    public class StaffMapper
    {
        public static StaffDto MapToDto(Staff staff)
        {
            return new StaffDto
            {
                TitleId = staff.TitleId,
                FirstName = staff.FirstName,
                LastName = staff.LastName
            };
        }

        public static Staff MapToStaff(StaffDto staffDto)
        {
            return new Staff
            {
                TitleId = staffDto.TitleId,
                FirstName = staffDto.FirstName,
                LastName = staffDto.LastName
            };
        }

        public static Staff AlignToStaff(Staff staff, StaffDto staffDto)
        {
            staff.TitleId = staffDto.TitleId;
            staff.FirstName = staffDto.FirstName;
            staff.LastName = staffDto.LastName;
            return staff;
        }
    }
}
