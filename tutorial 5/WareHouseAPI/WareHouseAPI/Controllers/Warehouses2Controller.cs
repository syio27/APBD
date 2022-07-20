using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouseAPI.Exceptions;
using WareHouseAPI.Models;
using WareHouseAPI.Services;

namespace WareHouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        private readonly IDatabaseServiceProcedure _dbService;
        public Warehouses2Controller(IDatabaseServiceProcedure dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public async Task<IActionResult> PostWarehouseProcedure(ProductWarehouseDTO dto)
        {
            try
            {
                int idProductWarehouse = await _dbService.AddOrderProcedure(dto);
            }
            catch (TransactionErrorException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
