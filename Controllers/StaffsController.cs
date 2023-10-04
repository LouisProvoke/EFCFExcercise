using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCFExcercise.Data;
using EFCFExcercise.Models;
using EFCFExcercise.Core;
using EFCFExcercise.Core.Repositories;
using EFCFExcercise.Models.Dto.Staff;

namespace EFCFExcercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            if (_unitOfWork.StaffRepository == null)
            {
                return Problem("'_unitOfWork.StaffRepository'  is null.");
            }
            IEnumerable<Staff> result = await _unitOfWork.StaffRepository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
          if (_unitOfWork.StaffRepository == null)
          {
                return Problem("'_unitOfWork.StaffRepository'  is null.");
            }
            var staff = await _unitOfWork.StaffRepository.GetAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, StaffDto staff)
        {
            if (_unitOfWork.StaffRepository == null)
            {
                return Problem("'_unitOfWork.StaffRepository'  is null.");
            }
            try
            {
                await _unitOfWork.StaffRepository.UpdateAsync(id,staff);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await StaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(StaffDto staff)
        {
          if (_unitOfWork.StaffRepository == null)
          {
              return Problem("Entity set 'EFCFExcerciseContext.Staff'  is null.");
          }
            await _unitOfWork.StaffRepository.AddAsync(staff);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetStaff", staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            if (_unitOfWork.StaffRepository == null)
            {
                return Problem("'_unitOfWork.StaffRepository'  is null.");
            }
            var staff = await _unitOfWork.StaffRepository.GetAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _unitOfWork.StaffRepository.Delete(staff);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> StaffExists(int id)
        {
            Staff StaffDetails = await _unitOfWork.StaffRepository.GetAsync(id);
            if (StaffDetails == null)
            {
                return false;
            }
            return true;
        }
    }
}
