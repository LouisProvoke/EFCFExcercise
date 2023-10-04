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
using EFCFExcercise.Models.Dto.Title;

namespace EFCFExcercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TitlesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Titles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetTitle()
        {
          if (_unitOfWork.TitleRepository == null)
          {
              return Problem("'_unitOfWork.TitleRepository' is null");
          }
            return Ok(await _unitOfWork.TitleRepository.GetAllAsync());
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(int id)
        {
          if (_unitOfWork.TitleRepository == null)
          {
              return NotFound();
          }
            var title = await _unitOfWork.TitleRepository.GetAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }

        // PUT: api/Titles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(int id, TitleDto title)
        {
            try
            {
                await _unitOfWork.TitleRepository.UpdateAsync(id, title);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TitleExists(id))
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

        // POST: api/Titles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Title>> PostTitle(TitleDto title)
        {
            if (_unitOfWork.TitleRepository == null)
            {
                return Problem("Entity set 'EFCFExcerciseContext.Title'  is null.");
            }

            await _unitOfWork.TitleRepository.AddAsync(title);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetTitle", title);
        }

        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(int id)
        {
            if (_unitOfWork.TitleRepository == null)
            {
                return Problem("Entity set 'EFCFExcerciseContext.Title'  is null.");
            }
            var title = await _unitOfWork.TitleRepository.GetAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            await _unitOfWork.TitleRepository.Delete(title);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> TitleExists(int id)
        {
            if (_unitOfWork.TitleRepository == null)
            {
                return false;
            }
            Title? title = await _unitOfWork.TitleRepository.GetAsync(id);
            if (title == null)
            {
                return false;
            }
            return true;
        }
    }
}
