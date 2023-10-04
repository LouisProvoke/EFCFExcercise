using EFCFExcercise.Data;
using EFCFExcercise.Models;
using EFCFExcercise.Models.Dto.Staff;
using Microsoft.AspNetCore.Http.HttpResults;
using EFCFExcercise.Mapper;
using Microsoft.EntityFrameworkCore;

namespace EFCFExcercise.Core.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(EFCFExcerciseContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<bool> AddAsync(StaffDto staffDto)
        {
            Staff newStaff = StaffMapper.MapToStaff(staffDto);
            return await this.AddAsync(newStaff);
        }

        public async Task<bool> UpdateAsync(int id, StaffDto staffDto)
        {
            Staff? staff = await this.GetAsync(id);
            if (staff == null)
            {
                throw new DbUpdateConcurrencyException();
            }
            staff = StaffMapper.AlignToStaff(staff, staffDto);
            return await this.Update(staff);
        }
    }
}
