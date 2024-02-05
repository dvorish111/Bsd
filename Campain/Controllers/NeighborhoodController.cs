using BL_AppService.IServeces;
using Common;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Campain.Controllers
{
    public class NeighborhoodController : BaseController
    {
         INeighborhoodService neighborhoodService;

        public NeighborhoodController(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NeighborhoodDTO neighborhoodDTO)
        {
            try
            {
                await neighborhoodService.Create(neighborhoodDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /* [HttpPut]
        public IActionResult Update( NeighborhoodDTO neighborhoodDTO)
        {
            try
            {
                neighborhoodService.Update(neighborhoodDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
*/
       /* [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                neighborhoodService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var neighborhoods = await neighborhoodService.GetAll();
                return Ok(neighborhoods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var neighborhood = await neighborhoodService.GetById(id);
                if (neighborhood == null)
                {
                    return NotFound();
                }
                return Ok(neighborhood);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
