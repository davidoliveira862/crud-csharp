using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using store.Data;
using store.Models;

namespace store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {

        private readonly AppDBContext _appDbContext;

        public StoreController(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostMethodStore([FromBody] Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adicionando produto
            _appDbContext.StoreImports.Add(store);
            await _appDbContext.SaveChangesAsync();

            return Created("Produto cadastrado com sucesso.", store);
        }
    }
}