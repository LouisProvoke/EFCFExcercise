using EFCFExcercise.Models;
using EFCFExcercise.Models.Dto.Staff;

namespace EFCFExcercise.Core
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        public Task<bool> AddAsync(StaffDto staffDto);
        public Task<bool> UpdateAsync(int id, StaffDto staffDto);
    }
}
