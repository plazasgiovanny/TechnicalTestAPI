using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestAPI.Entities;
using TechnicalTestAPI.GlobalModel;

namespace TechnicalTestAPI.Services
{
    public class SellerServices
    {

        private readonly ModelDbContext _context;

        public SellerServices(ModelDbContext context) { _context = context; }

        public async Task<ActionResult<IEnumerable<SELLER>>> GetAllSELLERs()
        {
            return await _context.SELLERs.ToListAsync();
        }


        public async Task<SELLER> GetSELLERById(int id)
        {
            return  await _context.SELLERs.FindAsync(id);
          
        }


        public async Task UpdateSELLER(SELLER sELLER)
        {

                _context.Entry(sELLER).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                    
        }

        public async Task<SELLER> CreateSELLER(SELLER sELLER)
        {
            _context.SELLERs.Add(sELLER);
            await _context.SaveChangesAsync();

            return sELLER;
        }


        public async Task DeleteSELLERbyId(int id)
        {
            var sELLER = await _context.SELLERs.FindAsync(id);
            if (sELLER is not null)
            {
                _context.SELLERs.Remove(sELLER);
                await _context.SaveChangesAsync();
            }           
        }



        public bool SELLERExists(int id)
        {
            return _context.SELLERs.Any(e => e.CODE == id);
        }

    }
}
