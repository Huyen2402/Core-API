using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhsController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public TinhsController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/Tinhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tinh>>> GetTinhs()
        {
            return await _context.Tinhs.ToListAsync();
        }

        // GET: api/Tinhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tinh>> GetTinh(int id)
        {
            var tinh = await _context.Tinhs.FindAsync(id);

            if (tinh == null)
            {
                return NotFound();
            }

            return tinh;
        }

        // PUT: api/Tinhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTinh(int id, Tinh tinh)
        {
            if (id != tinh.MaTinh)
            {
                return BadRequest();
            }

            _context.Entry(tinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TinhExists(id))
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

        // POST: api/Tinhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tinh>> PostTinh(Tinh tinh)
        {
            _context.Tinhs.Add(tinh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTinh", new { id = tinh.MaTinh }, tinh);
        }

        // DELETE: api/Tinhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTinh(int id)
        {
            var tinh = await _context.Tinhs.FindAsync(id);
            if (tinh == null)
            {
                return NotFound();
            }

            _context.Tinhs.Remove(tinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TinhExists(int id)
        {
            return _context.Tinhs.Any(e => e.MaTinh == id);
        }
    }
}
