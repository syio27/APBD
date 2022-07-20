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
    public class WarehousesController : ControllerBase
    {
        private readonly IDatabaseService _dbService;
        public WarehousesController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }
        [HttpPost]
        public async Task<IActionResult> PostWarehouse(ProductWarehouseDTO dto)
        {
            try
            {
                int idProductWarehouse = await _dbService.AddOrder(dto);
            }
            catch (DoesntExistException e)
            {
                return NotFound();
            }
            catch (OrderClosedException e)
            {
                return NotFound();
            }
            catch (UnableFulfillException e)
            {
                return NotFound();
            }
            catch (TransactionErrorException e)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
