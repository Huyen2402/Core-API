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
    public class PhieuNhapsController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public PhieuNhapsController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/PhieuNhaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuNhap>>> GetPhieuNhaps()
        {
            return await _context.PhieuNhaps.ToListAsync();
        }

        // GET: api/PhieuNhaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuNhap>> GetPhieuNhap(int id)
        {
            var phieuNhap = await _context.PhieuNhaps.FindAsync(id);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            return phieuNhap;
        }

        // PUT: api/PhieuNhaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieuNhap(int id, PhieuNhap phieuNhap)
        {
            if (id != phieuNhap.MaPn)
            {
                return BadRequest();
            }

            _context.Entry(phieuNhap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuNhapExists(id))
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

        // POST: api/PhieuNhaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhieuNhap>> PostPhieuNhap(PhieuNhap phieuNhap)
        {
            _context.PhieuNhaps.Add(phieuNhap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhieuNhap", new { id = phieuNhap.MaPn }, phieuNhap);
        }

        // DELETE: api/PhieuNhaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieuNhap(int id)
        {
            var phieuNhap = await _context.PhieuNhaps.FindAsync(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            _context.PhieuNhaps.Remove(phieuNhap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhieuNhapExists(int id)
        {
            return _context.PhieuNhaps.Any(e => e.MaPn == id);
        }
    }
}
