using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTestAPI.Entities;
using TechnicalTestAPI.Services;

namespace TechnicalTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SELLERsController : ControllerBase
    {
        private readonly SellerServices _service;

        public SELLERsController(SellerServices service)
        {
            _service = service;
        }

        // GET: api/SELLERs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SELLER>>> GetSELLERs()
        {
            return await _service.GetAllSELLERs();
        }

        // GET: api/SELLERs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SELLER>> GetSELLER(int id)
        {
            var sELLER = await _service.GetSELLERById(id);

            if (sELLER == null)
            {
                return NotFound();
            }

            return sELLER;
        }

        // PUT: api/SELLERs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSELLER(int id, SELLER sELLER)
        {
            if (id != sELLER.CODE)
            {
                return BadRequest();
            }

            if (!_service.SELLERExists(id))
            {
                return NotFound();
                
            }

            await _service.UpdateSELLER(sELLER);
            return NoContent();            
            
        }

        // POST: api/SELLERs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SELLER>> PostSELLER(SELLER sELLER)
        {
            var _newSeller =await _service.CreateSELLER(sELLER);
           
            return CreatedAtAction("GetSELLER", new { id = _newSeller.CODE }, _newSeller);
        }

        // DELETE: api/SELLERs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSELLER(int id)
        {
            if (!_service.SELLERExists(id))
            {
                return NotFound();
            }
       
            await _service.DeleteSELLERbyId(id);

            return NoContent();
        }

    }
}
